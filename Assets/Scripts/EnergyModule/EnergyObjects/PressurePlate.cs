using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergySource))]
public class PressurePlate : MonoBehaviour
{
  private BoxCollider2D colider;
  private EnergySource energy;
  private int colliders = 0;
  private AudioSettings audioSettings;

  // Start is called before the first frame update
  void Start()
  {
    this.colider = gameObject.GetComponent<BoxCollider2D>();
    this.energy = gameObject.GetComponent<EnergySource>();

    GameObject gameSettings = GameObject.Find("GameSettings");
    this.audioSettings = gameSettings.GetComponent<AudioSettings>();
  }

  // Update is called once per frame
  void Update()
  {
    if (this.colliders > 0) {
      this.energy.state = true;
    } else {
      this.energy.state = false;
    }
  }

  private void OnTriggerEnter2D(Collider2D otherCollider)
  {
    if (otherCollider.gameObject.tag == "Player")
    {
      if (this.colliders == 0) {
        gameObject.transform.Translate(0f, -0.010f, 0f);
        this.audioSettings.PlaySound("Plate");
      }

      this.colliders += 1;
    }

  }
  private void OnTriggerExit2D(Collider2D otherCollider)
  {

    if (otherCollider.gameObject.tag == "Player")
    {
      if (this.colliders == 1) {
        gameObject.transform.Translate(0f, +0.010f, 0f);
      }
      this.colliders -= 1;
    }

  }
}
