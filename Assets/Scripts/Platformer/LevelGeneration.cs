using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGeneration : MonoBehaviour
{
    public int level = 1;
    public LevelData[] data;

    Transform player;
    Vector2 startingLocation;
    System.Random random;

    Vector3 prevPlayerPosition;
    int tileIteration;

    float dstBtwTiles = 25;

    private void Start() {
        random = new System.Random();
        startingLocation = new Vector2(7.9f, 9.98f);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        for (int i = 0; tileIteration < 3; tileIteration++) {
            int index = random.Next(data[level].bgTiles.Count);
            Instantiate(data[level].bgTiles[index], startingLocation + Vector2.right * dstBtwTiles * tileIteration, Quaternion.identity);
        }

        prevPlayerPosition = player.position;
    }

    private void Update() {
        if ((player.position - prevPlayerPosition).magnitude >= dstBtwTiles) {
            int index = random.Next(data[level].bgTiles.Count);
            Instantiate(data[level].bgTiles[index], startingLocation + Vector2.right * dstBtwTiles * tileIteration, Quaternion.identity);

            prevPlayerPosition = player.position;
            tileIteration++;
        }
    }
}
