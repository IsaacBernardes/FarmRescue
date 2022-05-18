using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float moveTime;

    private float time;
    private int rig = 0;

    // Update is called once per frame
    void Update()
    {
        if(rig == 0){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else if(rig == 1){
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else {
            // da em nada comparça
        }

        time += Time.deltaTime;
        if(time >= moveTime && rig == 0){
            rig = 1;
            time = 0f;
        }
        if(time >= moveTime && rig == 1){
            rig = 0;
            time = 0f;
        }
        
    }
}
