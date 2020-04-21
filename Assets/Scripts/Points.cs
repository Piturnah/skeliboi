using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    Text points;
    bool playerDead;

    private void Start() {
        points = GetComponent<Text>();
        Player.onDeath += OnPlayerDeath;
    }

    private void OnDestroy() {
        Player.onDeath -= OnPlayerDeath;
    }

    private void Update() {
        if (!playerDead) {
            points.text = "Points: " + Mathf.RoundToInt(Time.timeSinceLevelLoad);
        }
    }

    void OnPlayerDeath() {
        playerDead = true;
    }
}
