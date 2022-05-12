using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergySource))]
public class Levers : MonoBehaviour
{
    private bool status = false;
    private Animator anim;
    private BoxCollider2D colider;
    private EnergySource energy;
    private AudioSettings audioSettings;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = gameObject.GetComponent<Animator>();
        this.colider = gameObject.GetComponent<BoxCollider2D>();
        this.energy = gameObject.GetComponent<EnergySource>();

        GameObject gameSettings = GameObject.Find("GameSettings");
        this.audioSettings = gameSettings.GetComponent<AudioSettings>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
  {
    if (otherCollider.gameObject.tag == "Player" && status == false)
    {
      status = true;
      anim.SetBool("leversAnim", false);
      this.energy.ToggleState();
      this.audioSettings.PlaySound("Toggle");
    }

    else if (otherCollider.gameObject.tag == "Player" && status == true)
    {
      status = false;
      anim.SetBool("leversAnim", true);
      this.energy.ToggleState();
      this.audioSettings.PlaySound("Toggle");
    }
    
  }

   
    
}
