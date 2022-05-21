using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gargalinha : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float moveTime;

    private float time;
    private int rig = 0;
    private LevelSettings levelSettings;
    private Animator animator;


    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        if (gameSettings != null) {
            this.levelSettings = gameSettings.GetComponent<LevelSettings>();
        }

        this.animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (this.levelSettings.paused) {
            return;
        }

        if(rig == 0){
            transform.Translate(Vector2.up * speed * Time.deltaTime * 0.5f);
        }
        else if(rig == 1){
            transform.Translate(Vector2.down * speed * Time.deltaTime * 2);
        }
        else {
            // da em nada comparça
        }

        time += Time.deltaTime;
        if(time >= (moveTime / 0.5f) && rig == 0){
            rig = 1;
            time = 0f;
            this.animator.SetTrigger("Fall");
        }
        if(time >= (moveTime/2) && rig == 1){
            rig = 0;
            time = 0f;
            this.animator.SetTrigger("Fly");
        }
        
    }
}
