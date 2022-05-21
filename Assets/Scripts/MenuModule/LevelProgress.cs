using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    public int levelMaxSeconds = 0;
    public int levelMaxFruits = 0;
    [HideInInspector]
    public int p1FruitsCollected = 0;
    [HideInInspector]
    public int p2FruitsCollected = 0;
    [HideInInspector]
    public float timeElipsed = 0f;
    private bool finished = false;

    private void Update() {
        if (!this.finished)
            timeElipsed += Time.deltaTime;
    }

    public void StopCount() {
        this.finished = true;
    }

    public void ContinueCount() {
        this.finished = false;
    }

    public int GetLevelScore() {
        int stars = 0;

        if (this.levelMaxSeconds * 0.50f > this.timeElipsed) {
            stars = 3;
        } else if (this.levelMaxSeconds > this.timeElipsed) {
            stars = 2;
        } else {
            stars = 1;
        }

        if (this.levelMaxFruits > this.p1FruitsCollected + this.p2FruitsCollected) {
            stars -= 1;
        }

        return stars;
    }
}
