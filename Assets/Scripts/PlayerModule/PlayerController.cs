using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public bool disableMovimentX = false;
    public float playerSpeed = 0.8f;
    public string leftKey = "a";
    public string rightKey = "d";
    public string jumpKey = "w";
    public bool hasDoubleJump = false;
    private float realSpeed = 0f;
    private Rigidbody2D rig;
    private Animator animator;
    private SpriteRenderer sprite;
    private int jumps = 1;
    private float reloadJump = 0.12f;
    private LevelSettings levelSettings;

    private void Start() {
        this.rig = gameObject.GetComponent<Rigidbody2D>();
        this.animator = gameObject.GetComponent<Animator>();
        this.sprite = gameObject.GetComponent<SpriteRenderer>();

        if (this.hasDoubleJump) {
            this.jumps = 2;
        }

        GameObject gameSettings = GameObject.Find("GameSettings");
        this.levelSettings = gameSettings.GetComponent<LevelSettings>();
    }

    private void Update() {

        if (this.levelSettings.paused) {
            this.realSpeed = 0;
            this.rig.velocity = new Vector3(0f, 0f, 0f);
            this.rig.gravityScale = 0f;
            this.animator.SetFloat("Speed", 0);
            this.jumps = 0;
            return;
        }

        this.rig.gravityScale = 0.2f;


        // START MOVIMENT

        if (Input.GetKeyDown(this.leftKey)) {
            this.realSpeed -= this.playerSpeed;
        }
        if (Input.GetKeyDown(this.rightKey)) {
            this.realSpeed += this.playerSpeed;
        }
        if (Input.GetKeyDown(this.jumpKey) && this.jumps > 0) {
            this.rig.velocity = new Vector3(this.rig.velocity.x, 0f, 0f);
            this.jumps -= 1;
            this.rig.AddForce(transform.up * 1.5f, ForceMode2D.Impulse);
        }


        // END MOVIMENT
        if (Input.GetKeyUp(this.leftKey)) {
            this.realSpeed -= this.playerSpeed * -1;
        }
        if (Input.GetKeyUp(this.rightKey)) {
            this.realSpeed += this.playerSpeed * -1;
        }

        
        this.animator.SetFloat("ySpeed", this.rig.velocity.y);
        this.animator.SetFloat("Speed", System.Math.Abs(this.realSpeed));

    }

    private void FixedUpdate() {

        if (this.levelSettings.paused) {
            return;
        }

        if (this.realSpeed < 0) {
            this.sprite.flipX = true;
        } else if (this.realSpeed > 0) {
            this.sprite.flipX = false;
        }

        if (this.rig.velocity.y < 0.1f && this.rig.velocity.y > -0.1f) {

            this.reloadJump -= Time.deltaTime;

            if (this.reloadJump <= 0) {
                this.jumps = 1;

                if (this.hasDoubleJump) {
                    this.jumps = 2;
                }
            }

        } else {
            this.reloadJump = 0.12f;
        }
        
        float xSpeed = this.realSpeed;
        if (disableMovimentX) {
            xSpeed = this.rig.velocity.x;
        }


        this.rig.velocity = new Vector3(xSpeed, this.rig.velocity.y, 0f);
    }
}
