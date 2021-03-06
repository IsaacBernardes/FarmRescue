using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Fruit : MonoBehaviour
{
    
    public string playerName;
    private bool collected = false;
    private Animator animator;
    private AudioSettings audioSettings;
    private LevelProgress levelProgress;
    [HideInInspector]
    public int playerNumber;

    private void Start() {
        this.animator = gameObject.GetComponent<Animator>();

        GameObject gameSettings = GameObject.Find("GameSettings");
        this.audioSettings = gameSettings.GetComponent<AudioSettings>();

        GameObject levelGameObject = GameObject.Find("LevelProgress");
        this.levelProgress = levelGameObject.GetComponent<LevelProgress>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (
            other.gameObject.tag == "Player" && 
            other.gameObject.name == this.playerName + "(Clone)" &&
            this.collected == false
        ) {
            this.collected =  true;
            this.audioSettings.PlaySound("Pick");
            this.animator.SetTrigger("Collect");

            if (this.levelProgress) {
                if (this.playerNumber == 1) {
                    this.levelProgress.p1FruitsCollected += 1;
                } else {
                    this.levelProgress.p2FruitsCollected += 1;
                }
                
            }
        }
    }

    public void DestroyItself() {
        Destroy(gameObject);
    }
}
