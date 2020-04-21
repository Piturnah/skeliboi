using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    float maxJumpHeight = 15f;
    float minJumpHeight = 3;
    float timeToJumpApex = .3f;
    float accelerationMultiplier = 0.2f;

    float initialVelocity = 30;
    float targetVelocity = 90;
    float timeToTargetVelocity = 300;

    public float gravity;
    public float maxJumpVelocity;
    float minJumpVelocity;
    public Vector3 velocity;

    public Controller2D controller;

    public float maxVelocity = 40;
    public static event Action onDeath;
    bool dead;

    private void Start() {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);

        velocity.x = maxVelocity;
    }

    private void Update() {
        maxVelocity = Mathf.Lerp(initialVelocity, targetVelocity, Mathf.Clamp01(Time.timeSinceLevelLoad / timeToTargetVelocity));

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && controller.collisions.below) {
            velocity.y = maxJumpVelocity;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow)) {
            if (velocity.y > minJumpVelocity) {
                velocity.y = minJumpVelocity;
            }
        }

        velocity.x += maxVelocity * accelerationMultiplier * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, 0, maxVelocity);
        velocity.y += gravity * Time.deltaTime;
        if (!dead) {
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy") {
            onDeath?.Invoke();
            dead = true;
            GetComponent<Animator>().enabled = false;
        }
    }
}
