using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSettings : MonoBehaviour
{

    #region Singleton
    public static LevelSettings instance;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public int numberOfLevels = 6;

    [HideInInspector]
    public int completedLevels = 0;

    [HideInInspector]
    public List<int> levelStars;

    public bool paused = false;

    private void Start() {
        this.levelStars = new List<int>();
        for (int i = 0; i < this.numberOfLevels; i++) {
            this.levelStars.Add(0);
        }
    }

    public void CompleteLevel(int level, int stars) {

        if (this.completedLevels < level) {
            this.completedLevels = level;
        }

        if (this.levelStars[level-1] < stars) {
            this.levelStars[level-1] = stars;
        }
    }
}
