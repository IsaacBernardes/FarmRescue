using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSlider : MonoBehaviour, EnergyPoint
{
    public float slideAmount = 1f;
    public Direction slideDirection = Direction.HORIZONTAL;
    public float smooth = 2f;
    public bool loadInverter = false;
    public EnergySource energySource1;
    public EnergySource energySource2;
    private bool actualState;
    private Vector3 newPosition;

    void Start()
    {
        this.newPosition = gameObject.transform.position;
    }

    private void Update() {
        
      if(energySource1.state){
            energy1();
      }else{
          energy2();
      }

    }

    public void energy1() {
        
        bool state = energySource1.state;

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

    public void energy2() {
        
        bool state = energySource2.state;

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
