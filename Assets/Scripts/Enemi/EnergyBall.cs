using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    private GameObject[] players;
    private Rigidbody2D rig;
    private Vector3 direction;
    private bool shot = false;
    private float autoDestroyTimeout = 2f;
    private LevelSettings levelSettings;

    private void Start() {
        this.players = GameObject.FindGameObjectsWithTag("Player");
        this.rig = gameObject.GetComponent<Rigidbody2D>();
        
        GameObject gameSettingsGO = GameObject.Find("GameSettings");
        if (gameSettingsGO) {
            this.levelSettings = gameSettingsGO.GetComponent<LevelSettings>();
        }
    }

    private void Update() {
        if (this.shot) {
            this.autoDestroyTimeout -= Time.deltaTime;
        }

        if (autoDestroyTimeout <= 0) {
            Destroy(gameObject);
        }
    }

    public void Shot() {
        if (!this.levelSettings.paused) {
            int selectedPlayerIndex = Random.Range(0, this.players.Length);
            GameObject selectedPlayer = this.players[selectedPlayerIndex];
            this.direction = selectedPlayer.transform.position - gameObject.transform.position;
            this.shot = true;
            this.rig.AddForce(this.direction * 1.2f, ForceMode2D.Impulse);
        } else {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        GameObject go = other.gameObject;

        if (go.tag == "Player") {
            PlayerController playerController = go.GetComponent<PlayerController>();
            playerController.Die();
        }
    }
}
