using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public GameObject canvasObject;
    public TextMeshProUGUI textField;

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
}
