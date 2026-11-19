using System;
using UnityEngine;

public class HitKreisScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("hier");
        if (other.gameObject.CompareTag("Dreieck"))
        {
               Debug.Log("Test");
               Time.timeScale = 0;
        }
    }
}
