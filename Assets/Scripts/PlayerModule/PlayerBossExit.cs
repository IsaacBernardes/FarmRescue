using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerBossExit : MonoBehaviour
{
    public int level = 7;
    private BoxCollider2D colider;
    private List<GameObject> players = new List<GameObject>();
    private LevelSettings levelSettings;

    private void Start() {
        this.colider = gameObject.GetComponent<BoxCollider2D>();

        GameObject gameSettings = GameObject.Find("GameSettings");
        this.levelSettings = gameSettings.GetComponent<LevelSettings>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player") {
            this.players.Add(otherCollider.gameObject);
        }

        if (this.players.Count == 2) {

            while (this.players.Count > 0) {
                GameObject player = this.players[0];
                Destroy(player);
            }

            this.levelSettings.CompleteLevel(this.level, 3);
            SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
        }

    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {

        if (otherCollider.gameObject.tag == "Player") {
            this.players.Remove(otherCollider.gameObject);
        }

    }
}
