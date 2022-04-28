using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour, EnergyPoint
{
    public float slideAmount = 1f;
    public Direction slideDirection = Direction.HORIZONTAL;
    public float smooth = 2f;
    public bool loadInverter = false;
    public EnergySource energySource;
    private bool actualState;
    private Vector3 newPosition;

    void Start()
    {
        this.newPosition = gameObject.transform.position;
    }

    private void Update() {
        
        bool state = energySource.state;

        if (loadInverter) {
            state = !state;
        }

        if (actualState != state) {
            this.actualState = state;

            if (actualState) {
                this.SwitchOn();
            } else {
                this.SwitchOff();
            }
        }

        if (this.newPosition != null) {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * this.smooth);
        }

    }

    public void SwitchOn(){
           
        switch (slideDirection) {
            case Direction.HORIZONTAL:
                this.newPosition = this.newPosition + transform.right * slideAmount;
                break;
            case Direction.VERTICAL:
                this.newPosition = this.newPosition + transform.up * slideAmount;
                break;
        }
    }

    public void SwitchOff(){

        switch (slideDirection) {
            case Direction.HORIZONTAL:
                this.newPosition = this.newPosition + transform.right * slideAmount * -1;
                break;
            case Direction.VERTICAL:
                this.newPosition = this.newPosition + transform.up * slideAmount * -1;
                break;
        }
    }
    
}