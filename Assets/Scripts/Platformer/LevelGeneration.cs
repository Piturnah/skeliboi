using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGeneration : MonoBehaviour
{
    public int level = 1;
    public LevelData[] data;
    public GameObject wallTile;

    Transform player;
    Vector2 startingLocation;
    System.Random random;

    Vector3 prevPlayerPosition;
    int tileIteration;
    int timeSinceTransition;

    int dstBtwTiles = 25;
    int currentLevel;

    private void Start() {
        random = new System.Random();
        currentLevel = level;
        startingLocation = new Vector2(8, 10);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        for (int i = 0; tileIteration < 4; tileIteration++) {
            int index = random.Next(data[level].bgTiles.Count);
            Instantiate(data[level].bgTiles[index], startingLocation + Vector2.right * dstBtwTiles * tileIteration, Quaternion.identity);
        }

        prevPlayerPosition = player.position;
    }

    bool transitioning;
    int transitionTime;
    private void Update() {
        if (player.position.x - prevPlayerPosition.x >= dstBtwTiles) {

            if (!transitioning && (timeSinceTransition <= 7 || random.NextDouble() > 0.1)) {
                NewTile();
                timeSinceTransition++;
            }
            else {
                transitioning = true;
                Transition();
                transitionTime++;

                if (transitionTime >= 3) {
                    transitionTime = 0;
                    transitioning = false;
                    timeSinceTransition = 0;
                    currentLevel = level;
                }
            }
        }
    }

    void NewTile() {
        Vector2 position = startingLocation + Vector2.right * dstBtwTiles * tileIteration;

        int index = random.Next(data[level].bgTiles.Count);
        Instantiate(data[level].bgTiles[index], position, Quaternion.identity);

        prevPlayerPosition = player.position;
        tileIteration++;

        if (random.NextDouble() > 0.5) {
            index = random.Next(data[level].hazards.Count);
            Instantiate(data[level].hazards[index], new Vector2(position.x - 25/6, -0.6f), Quaternion.identity);
        }

        if (random.NextDouble() > 0.5) {
            index = random.Next(data[level].hazards.Count);
            Instantiate(data[level].hazards[index], new Vector2(position.x + 25 / 6, -0.6f), Quaternion.identity);
        }
    }

    void Transition() {
        Vector2 position = startingLocation + Vector2.right * dstBtwTiles * tileIteration;

        Instantiate(wallTile, position, Quaternion.identity);

        prevPlayerPosition = player.position;
        tileIteration++;

        while (level == currentLevel) {
            level = random.Next(5);
        }
    }
}
