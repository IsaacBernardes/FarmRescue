using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public Direction windDirection = Direction.VERTICAL;   
    public float force = 1f;
    public bool loadInverter = false;
    public EnergySource energySource;
    public Animator animator;
    private bool actualState;
    private List<Rigidbody2D> rigList = new List<Rigidbody2D>();
    private List<PlayerController> playerList = new List<PlayerController>();
    


    private void Start() {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0f);
    }


    // Update is called once per frame
    void Update()
    {
        bool state = energySource.state;

        if (loadInverter) {
            state = !state;
        }
        
        this.animator.SetBool("On/Off", state);

        bool changed = false;
        if (actualState != state) {
            this.actualState = state;
            changed = true;
        }


        if(actualState){
            float xForce, yForce;

            foreach (Rigidbody2D item in rigList){
                if(this.windDirection == Direction.VERTICAL){
                    xForce = item.velocity.x;
                    yForce = this.force;
                }
                else{
                    xForce = this.force;
                    yForce = item.velocity.y;
                    item.AddForce(new Vector3(this.force, 0f, 0f));
                }
                item.velocity = new Vector3(xForce, yForce, 0f);
            }

            if (changed && this.windDirection == Direction.HORIZONTAL) {
                foreach (PlayerController p in playerList){
                    p.disableMovimentX = true;
                }
            }

        } else if (!actualState && changed && this.windDirection == Direction.HORIZONTAL) {
            foreach (PlayerController p in playerList){
                p.disableMovimentX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Rigidbody2D rig = other.gameObject.GetComponent<Rigidbody2D>();
        if(rig != null){
            this.rigList.Add(rig);        
        }

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null) {
            this.playerList.Add(player);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Rigidbody2D rig = other.gameObject.GetComponent<Rigidbody2D>();
        if(rig != null && rigList.Contains(rig)){
            this.rigList.Remove(rig);        
        }

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(player != null && playerList.Contains(player)){
            this.playerList.Remove(player);      
            player.disableMovimentX = false;
        }
    }
}
