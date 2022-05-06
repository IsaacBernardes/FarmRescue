using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerExit : MonoBehaviour
{
    private BoxCollider2D colider;
    private List<GameObject> players = new List<GameObject>();

    private void Start() {
        this.colider = gameObject.GetComponent<BoxCollider2D>();
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
        }

    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {

        if (otherCollider.gameObject.tag == "Player") {
            this.players.Remove(otherCollider.gameObject);
        }

    }
}
