using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTile : MonoBehaviour
{
    public Transform player;

    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void Update() {
        if ((player.position - transform.position).magnitude > 110) {
            Destroy(gameObject);
        }
    }
}
