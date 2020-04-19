using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class EnemyController : MonoBehaviour
{
    float moveAcceleration = 7;
    Vector3 velocity;

    Controller2D controller;
    Transform player;

    private void Start() {
        controller = GetComponent<Controller2D>();
        velocity.x = 39;
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        velocity.x += moveAcceleration * Time.deltaTime;
        velocity.x = Mathf.Clamp(velocity.x, 0, ((player.position - transform.position).magnitude > 12f) ? 40 : 39);
        controller.Move(velocity * Time.deltaTime);
    }
}
