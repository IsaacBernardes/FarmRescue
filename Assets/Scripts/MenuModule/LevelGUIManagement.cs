using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGUIManagement : MonoBehaviour
{
    public int level;
    public SpriteRenderer star1;
    public SpriteRenderer star2;
    public SpriteRenderer star3;
    public SpriteRenderer locker;
    private bool locked = false;

    private void Start() {
        GameObject gameSettings = GameObject.Find("GameSettings");
        LevelSettings levelSettings = gameSettings.GetComponent<LevelSettings>();

        if (this.level-1 <= levelSettings.completedLevels) {
            this.locker.sprite = null;

            if (this.level-1 == levelSettings.completedLevels) {
                this.star1.sprite = null;
                this.star2.sprite = null;
                this.star3.sprite = null;
                return;
            }
            
        } else {
            this.locked = true;
            this.star1.sprite = null;
            this.star2.sprite = null;
            this.star3.sprite = null;
            return;
        }


        Color black = new Color(0f, 0f, 0f, 1f);
        int starNumbers = levelSettings.levelStars[this.level-1];
        if (starNumbers < 3) { this.star3.color = black; }
        if (starNumbers < 2) { this.star2.color = black; }
        if (starNumbers < 1) { this.star1.color = black; }

    }

    public void PlayLevel() {
        if (locked) {
            return;
        }

        string levelName = "Level " + this.level;
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

}
