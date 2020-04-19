using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class EnemyController : MonoBehaviour
{
    float moveAcceleration = 10;
    Vector3 velocity;

    Controller2D controller;

    private void Start() {
        controller = GetComponent<Controller2D>();
    }

    void Update()
    {
        velocity.x += moveAcceleration * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, 0, 50);
        controller.Move(velocity * Time.deltaTime);
    }
}
