using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    float jumpHeight = 2;
    float timeToJumpApex = .2f;
    float moveAcceleration = 10;

    public float gravity;
    public float jumpVelocity;
    public Vector3 velocity;

    public Controller2D controller;

    private void Start() {
        controller = GetComponent<Controller2D>();

        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    private void Update() {

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && controller.collisions.below) {
            velocity.y = jumpVelocity;
        }

        velocity.x += moveAcceleration * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, 0, 50);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
