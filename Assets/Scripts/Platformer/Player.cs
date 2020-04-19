using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    float maxJumpHeight = 10;
    float minJumpHeight = 1;
    float timeToJumpApex = .4f;
    float moveAcceleration = 10;

    public float gravity;
    public float maxJumpVelocity;
    float minJumpVelocity;
    public Vector3 velocity;

    public Controller2D controller;

    private void Start() {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update() {

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

        velocity.x += moveAcceleration * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, 0, 50);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
