using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Spawn : MonoBehaviour
{
    [Range(1, 2)]
    public int player = 1;

    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        PlayerSettings playerSettings = gameSettings.GetComponent<PlayerSettings>();

        string prefabName = "";
        string prefabUp = "";
        string prefabLeft = "";
        string prefabRight = "";

        if (this.player == 1) {
            prefabName = playerSettings.p1Name;
            prefabUp = playerSettings.p1Jump;
            prefabLeft = playerSettings.p1Left;
            prefabRight = playerSettings.p1Right;
        } else {
            prefabName = playerSettings.p2Name;
            prefabUp = playerSettings.p2Jump;
            prefabLeft = playerSettings.p2Left;
            prefabRight = playerSettings.p2Right;
        }

        Player p = Array.Find(playerSettings.players, pl => pl.name == prefabName);

        if (p != null) {
            GameObject pl = Instantiate(
                p.prefab,
                gameObject.transform.position,
                gameObject.transform.rotation
            );

            pl.tag = "Player";
            PlayerController controller = pl.GetComponent<PlayerController>();
            controller.jumpKey = prefabUp;
            controller.leftKey = prefabLeft;
            controller.rightKey = prefabRight;
        }

        Destroy(gameObject);
    }

    
}
