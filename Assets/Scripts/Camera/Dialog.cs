using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject canvasObject;
    public TextMeshProUGUI textField;
    private AudioSettings audioSettings;

    private void Start() {
        GameObject go = GameObject.Find("GameSettings");

        if (go != null) {
            this.audioSettings = go.GetComponent<AudioSettings>();
        }
    }

    public void ClearText() {
        this.textField.text = "";
    }

    public void SetText(string text) {
        this.textField.text = text;
    }

    public void EnableDialog() {
        this.canvasObject.SetActive(true);
    }

    public void DisableDialog() {
        this.canvasObject.SetActive(false);
    }

    public void PlaySound(string sound) {
        this.audioSettings.PlaySound(sound);
    }

    public void StopAllMusics() {
        this.audioSettings.StopAllMusics();
    }
}
