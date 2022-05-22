using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitSpawn : MonoBehaviour
{
    [Range(1, 2)]
    public int player = 1;

    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        PlayerSettings playerSettings = gameSettings.GetComponent<PlayerSettings>();

        string pName;

        if (this.player == 1) {
            pName = playerSettings.p1Name;
        } else {
            pName = playerSettings.p2Name;
        }

        Player p = Array.Find(playerSettings.players, pl => pl.name == pName);

        if (p != null) {
            GameObject fruit = Instantiate(
                p.fruit,
                gameObject.transform.position,
                gameObject.transform.rotation
            );
            Fruit f = fruit.GetComponent<Fruit>();
            f.playerNumber = this.player;
        }

        Destroy(gameObject);
    }

    
}
