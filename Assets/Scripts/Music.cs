using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start() {
        Player.onDeath += OnPlayerDeath;
    }

    private void OnDestroy() {
        Player.onDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath() {
        Destroy(gameObject);
    }
}
