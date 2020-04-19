using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    Transform player;
    public LevelData data;
    Vector2 startingLocation;

    private void Start() {
        startingLocation = new Vector2(-1.49f, 1.9f);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        for (int i = 0; i < 3; i++) {

        }
    }
}
