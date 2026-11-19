using System;
using UnityEngine;

public class FalschHitScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("hit");
        if (other.CompareTag("Dreieck"))
        {
           Debug.Log("Falsches Ziel");
           Time.timeScale = 0;
        }

    }
}
