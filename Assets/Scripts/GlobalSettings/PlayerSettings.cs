using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    #region Singleton
    public static PlayerSettings instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion
    
    public string p1Name = "Breno";
    public string p1Jump = "w";
    public string p1Left = "a";
    public string p1Right = "d";
    public string p2Name = "Flavin";
    public string p2Jump = "up";
    public string p2Left = "left";
    public string p2Right = "right";
    public Player[] players;

    void Start() {
        
    }

    
    void Update() {
        
    }
}
