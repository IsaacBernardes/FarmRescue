using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PauseScript : MonoBehaviour
{
    public TextMeshProUGUI timeField;
    public TextMeshProUGUI GUITimeField;
    public TextMeshProUGUI p1Fruits;
    public TextMeshProUGUI p2Fruits;
    public SpriteRenderer imageP1Fruits;
    public SpriteRenderer imageP2Fruits;
    private LevelProgress levelProgress;
    private LevelSettings levelSettings;

    private void Start() {
        GameObject lvlGameObject = GameObject.Find("LevelProgress");
        if (lvlGameObject != null) {
            this.levelProgress = lvlGameObject.GetComponent<LevelProgress>();
        }

        GameObject gameSettings = GameObject.Find("GameSettings");
        if (gameSettings != null) {
            this.levelSettings = gameSettings.GetComponent<LevelSettings>();

            PlayerSettings playerSettings = gameSettings.GetComponent<PlayerSettings>();
            Player p1 = Array.Find(playerSettings.players, player => player.name == playerSettings.p1Name);
            Player p2 = Array.Find(playerSettings.players, player => player.name == playerSettings.p2Name);

            this.imageP1Fruits.sprite = p1.fruit.GetComponent<SpriteRenderer>().sprite;
            this.imageP2Fruits.sprite = p2.fruit.GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void Update() {
        if (levelProgress != null) {
            int timeElipsed =  this.levelProgress.levelMaxSeconds - ((int) this.levelProgress.timeElipsed);
            int minutes = (int) (Mathf.Floor(timeElipsed/60));
            int seconds = timeElipsed - minutes * 60;
            
            if (this.timeField) {
            
                if (timeElipsed <= 0) {
                    seconds = 0;
                    this.timeField.color = Color.red;
                } else if (this.levelProgress.timeElipsed > this.levelProgress.levelMaxSeconds/2) {
                    this.timeField.color = Color.yellow;
                }
            
            
                this.timeField.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }

            minutes = (int) (Mathf.Floor(this.levelProgress.timeElipsed/60));
            seconds = ((int) this.levelProgress.timeElipsed) - minutes * 60;
            this.GUITimeField.text = minutes.ToString("00") + ":" + seconds.ToString("00");


            this.p1Fruits.text = this.levelProgress.p1FruitsCollected.ToString();
            this.p2Fruits.text = this.levelProgress.p2FruitsCollected.ToString();
        }
    }

    public void PauseGame() {
        this.levelProgress.StopCount();
        this.levelSettings.paused = true;
    }

    public void ResumeGame() {
        this.levelProgress.ContinueCount();
        this.levelSettings.paused = false;
    }
}
