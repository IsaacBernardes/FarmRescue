using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WAB : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;

        if (go.tag == "Boss") {
            DrM drM = go.GetComponent<DrM>();
            drM.TakeDamage();
            Destroy(gameObject);
        }
    }
}
