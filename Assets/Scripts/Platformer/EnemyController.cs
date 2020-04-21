using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Player player;
    float offsetX = -30;
    float velocityMultiplier = 0.7f;
    AudioSource audio;

    bool playerDead;

    private void Start() {

        Player.onDeath += OnPlayerDies;
        gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();

        player = FindObjectOfType<Player>().GetComponent<Player>();
        Controller2D.onHit += OnPlayerHitsHazard;
    }

    private void OnDestroy() {
        Controller2D.onHit -= OnPlayerHitsHazard;
        Player.onDeath -= OnPlayerDies;
    }

    private void Update() {
        if (gameObject.activeInHierarchy && !playerDead) {
            transform.Translate(Vector3.right * player.maxVelocity * velocityMultiplier * Time.deltaTime);
        }

        if ((player.transform.position - transform.position).magnitude > 50) {
            gameObject.SetActive(false);
        }
    }

    void OnPlayerHitsHazard() {
        if (!gameObject.activeInHierarchy) {
            transform.position = new Vector3(player.transform.position.x + offsetX, - 0.29f, -5f);
            gameObject.SetActive(true);
            audio.Play();
        }
    }

    void OnPlayerDies() {
        playerDead = true;
        GetComponentInChildren<Animator>().enabled = false;
    }
}