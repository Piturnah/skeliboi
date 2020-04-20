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

    int dstBtwTiles = 25;

    private void Start() {
        random = new System.Random();
        startingLocation = new Vector2(8, 10);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        for (int i = 0; tileIteration < 4; tileIteration++) {
            int index = random.Next(data[level].bgTiles.Count);
            Instantiate(data[level].bgTiles[index], startingLocation + Vector2.right * dstBtwTiles * tileIteration, Quaternion.identity);
        }

        prevPlayerPosition = player.position;
    }

    private void Update() {
        if (player.position.x - prevPlayerPosition.x >= dstBtwTiles) {
            NewTile();
        }
    }

    void NewTile() {
        Vector2 position = startingLocation + Vector2.right * dstBtwTiles * tileIteration;

        int index = random.Next(data[level].bgTiles.Count);
        Instantiate(data[level].bgTiles[index], position, Quaternion.identity);

        prevPlayerPosition = player.position;
        tileIteration++;

        if (random.NextDouble() > 0.2) {
            index = random.Next(data[level].hazards.Count);
            Instantiate(data[level].hazards[index], new Vector2(position.x, -0.6f), Quaternion.identity);
        }
    }
}
