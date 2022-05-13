using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public string playOnStart;
    private AudioSettings audioSettings;
    
    void Start()
    {
        GameObject gameSettings = GameObject.Find("GameSettings");
        this.audioSettings = gameSettings.GetComponent<AudioSettings>();

        if (playOnStart != null)
            audioSettings.PlaySound(playOnStart);
    }

    public void PlaySound(string soundName) {
        audioSettings.PlaySound(soundName);
    }

    public void StopAllMusics() {
        audioSettings.StopAllMusics();
    }

}
