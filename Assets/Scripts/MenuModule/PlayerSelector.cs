using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerSelector : MonoBehaviour
{
    public Image p1BodyImage;
    public Image p1FruitImage;
    public TextMeshProUGUI p1Name;
    public TextMeshProUGUI p1Power;
    public Image p2BodyImage;
    public Image p2FruitImage;
    public TextMeshProUGUI p2Name;
    public TextMeshProUGUI p2Power;
    public TextMeshProUGUI money;
    private PlayerSettings playerSettings;
    private LevelSettings levelSettings;

    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        this.playerSettings = gameSettings.GetComponent<PlayerSettings>();
        this.levelSettings = gameSettings.GetComponent<LevelSettings>();
    }

    private void FixedUpdate() {
        this.p1Name.text = this.playerSettings.p1Name;
        this.p1Power.text = this.playerSettings.p1Name == "Breno" ? "Pulo Duplo" : this.playerSettings.p1Name == "Cleitin" ? "Vida Extra" : "Veloz" ;
        Player p1 = Array.Find<Player>(this.playerSettings.players, player => player.name == this.playerSettings.p1Name);
        this.p1BodyImage.sprite = p1.prefab.GetComponent<SpriteRenderer>().sprite;
        this.p1FruitImage.sprite = p1.fruit.GetComponent<SpriteRenderer>().sprite;

        this.p2Name.text = this.playerSettings.p2Name;
        this.p2Power.text = this.playerSettings.p2Name == "Breno" ? "Pulo Duplo" : this.playerSettings.p2Name == "Cleitin" ? "Vida Extra" : "Veloz" ;
        Player p2 = Array.Find<Player>(this.playerSettings.players, player => player.name == this.playerSettings.p2Name);
        this.p2BodyImage.sprite = p2.prefab.GetComponent<SpriteRenderer>().sprite;
        this.p2FruitImage.sprite = p2.fruit.GetComponent<SpriteRenderer>().sprite;

        int stars = 0;
        foreach (int star in this.levelSettings.levelStars) {
            stars += star;
        }
        stars -= this.levelSettings.starsSpended;
        int diamonds = (int) Mathf.Floor(stars/3);
        this.money.text = diamonds.ToString();
    }

    public void ChangePlayer(int number) {

        if (int.Parse(this.money.text) <= 0) {
            return;
        }

        this.levelSettings.starsSpended += 3;
        string[] playerNameList = new string[]{"Breno", "Cleitin", "Zezin"};
        string anotherPlayer = Array.Find<string>(playerNameList, player => player != this.p1Name.text && player != this.p2Name.text);
        
        if (number == 1) {
            this.playerSettings.p1Name = anotherPlayer;
        } else if (number == 2) {
            this.playerSettings.p2Name = anotherPlayer;
        }
    }

    public void SwitchPlayers() {
        string p1 = this.playerSettings.p1Name;
        this.playerSettings.p1Name = this.playerSettings.p2Name;
        this.playerSettings.p2Name = p1;
    }
}
