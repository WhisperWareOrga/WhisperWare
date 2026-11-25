using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCDialogue : MonoBehaviour
{
    public DialogueData dialogue; // Dialog für bestimmten NPC
    public GameObject prompt;

    private bool playerNear;
    // Update is called once per frame
    void Update()
    {
        bool cantalk = playerNear && !DialogueManager.Instance.isTalking;
        if(prompt) prompt.SetActive(cantalk);

        if(cantalk && Mouse.current.leftButton.wasPressedThisFrame)
            DialogueManager.Instance.StartDialogue(dialogue);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNear = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNear = false;
    }
}
