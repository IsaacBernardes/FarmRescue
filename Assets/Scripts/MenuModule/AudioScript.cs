using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    public Slider musicVolume;
    public Slider soundVolume;
    private AudioSettings audioSettings;

    void Start()
    {
        GameObject gameSettings = GameObject.Find("GameSettings");
        this.audioSettings = gameSettings.GetComponent<AudioSettings>();

        this.musicVolume.value = (float) this.audioSettings.musicVolume;
        this.soundVolume.value = (float) this.audioSettings.soundVolume;
    }

    public void UpdateSoundVolume() {
        this.audioSettings.UpdateSoundVolume((int) this.soundVolume.value);
        this.audioSettings.PlaySound("Toggle");
    }

    public void UpdateMusicVolume() {
        this.audioSettings.UpdateMusicVolume((int) this.musicVolume.value);
    }
}
