using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergySource))]
public class PressurePlate : MonoBehaviour
{
  private BoxCollider2D colider;
  private EnergySource energy;
  // Start is called before the first frame update
  void Start()
  {
    this.colider = gameObject.GetComponent<BoxCollider2D>();
    this.energy = gameObject.GetComponent<EnergySource>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnTriggerEnter2D(Collider2D otherCollider)
  {
    if (otherCollider.gameObject.tag == "Player")
    {
      gameObject.transform.Translate(0f, -0.010f, 0f);
      this.energy.ToggleState();
    }

  }
  private void OnTriggerExit2D(Collider2D otherCollider)
  {
    if (otherCollider.gameObject.tag == "Player")
    {
      gameObject.transform.Translate(0f, +0.010f, 0f);
      this.energy.ToggleState();
    }

  }
}
