using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject endMenu;

    private void Start() {
        Player.onDeath += OnPlayerDeath;

        endMenu = GameObject.FindGameObjectWithTag("EndScreen");
        endMenu.SetActive(false);
    }

    private void OnDestroy() {
        Player.onDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath() {
        endMenu.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void MenuButton() {
        SceneManager.LoadScene(0);
    }
}
