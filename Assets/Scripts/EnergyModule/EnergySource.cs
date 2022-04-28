using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour
{
    public bool initialState = false;

    [HideInInspector]
    public bool state;


    private void Start() {
        this.state = initialState;
    }

    public void ToggleState() {
        this.state = !this.state;
    }
}
