using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    public Player player;

    public GameObject debugMenu;
    public Text playerCollisionsBelow;
    public Text playerGravity;
    public Text playerJumpVelocity;
    public Text playerVelocity;

    bool showingDebug = true;

    private void Update() {
        if (Input.GetKeyUp(KeyCode.F3)) {
            showingDebug = !showingDebug;
            debugMenu.SetActive(showingDebug);
        }

        if (showingDebug) {
            playerCollisionsBelow.text = "Grounded: " + ((player.controller.collisions.below) ? "true" : "false");
            playerGravity.text = "Gravity: " + player.gravity;
            playerJumpVelocity.text = "Jump velocity: " + player.jumpVelocity;
            playerVelocity.text = "Velocity X: " + player.velocity.x + " Y: " + player.velocity.y;
        }

    }
}
