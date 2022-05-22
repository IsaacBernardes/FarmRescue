using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerExit : MonoBehaviour
{
    public int level = 1;
    private BoxCollider2D colider;
    private List<GameObject> players = new List<GameObject>();
    private LevelSettings levelSettings;
    private LevelProgress levelProgress;

    private void Start() {
        this.colider = gameObject.GetComponent<BoxCollider2D>();

        GameObject gameSettings = GameObject.Find("GameSettings");
        this.levelSettings = gameSettings.GetComponent<LevelSettings>();

        GameObject levelGameObject = GameObject.Find("LevelProgress");
        this.levelProgress = levelGameObject.GetComponent<LevelProgress>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player") {
            this.players.Add(otherCollider.gameObject);
        }

        if (this.players.Count == 2) {
            int stars = 0;

            if (this.levelProgress) {
                this.levelProgress.StopCount();
                stars = this.levelProgress.GetLevelScore();
            }

            while (this.players.Count > 0) {
                this.levelSettings.CompleteLevel(this.level, stars);
                GameObject player = this.players[0];
                Destroy(player);
                this.levelProgress.Win();
            }
        }

    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {

        if (otherCollider.gameObject.tag == "Player") {
            this.players.Remove(otherCollider.gameObject);
        }

    }
}
