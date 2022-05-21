using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float moveTime;

    private int rig = 0;
    private float time;
    public Transform head;
    private LevelSettings levelSettings;

    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        if (gameSettings != null) {
            this.levelSettings = gameSettings.GetComponent<LevelSettings>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.levelSettings.paused) {
            return;
        }

        if(rig == 0){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(rig == 1){
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if(rig == 2){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if(rig == 3){
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else{
            //
        }

        time += Time.deltaTime;
        if(time >= moveTime && rig == 0){
            rig = 1;
            time = 0f;
        }
        if(time >= moveTime && rig == 1){
            rig = 2;
            time = 0f;
        }
        if(time >= moveTime && rig == 2){
            rig = 3;
            time = 0f;
        }
         if(time >= moveTime && rig == 3){
            rig = 0;
            time = 0f;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        GameObject go = other.gameObject;

        if (go.tag == "Player") {
            PlayerController playerController = go.GetComponent<PlayerController>();
            playerController.Die();
        }
    }
}
