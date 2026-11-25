using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

/*
 * Anleitung:
 *  im Dialog Ordner rechts klick (Create -> Dialogue (steht weit unten))
 *  Bei Lines Der Dialog Text und Choice die Antwort möglichkeiten
 *  Bei Next muss man den Nächsten Dialog reinziehen der dann ausgeführt wird.
 *      NPC/ Gast brauhct as NPC skript
 *      bei Dialog das Start Dialog reinpacken
 *      und bei prompt ein text reinziehen
 *
 */

// TO DO
// NPC geht rein
// zeile 82 NPC geht raus

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject panel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Transform choiceContainer;
    public Button choiceButtonPrefab;
    public float typespeed = 0.03f;
    
    public bool isTalking { get; private set; }

    private DialogueData current;
    private int index;
    private bool typing;
    private bool choosing;

    private void Awake()
    {
        Instance = this;
        panel.SetActive(false);
    }

    void Update()
    {
        if (!isTalking || choosing) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (typing) SkipTyping();
            else NextLine();
        }
    }

    public void StartDialogue(DialogueData data)
    {
        StopAllCoroutines();
        current = data;
        index = 0;
        isTalking = true;
        panel.SetActive(true);
        nameText.text = data.name;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine() 
    {
        typing = true;
        dialogueText.text = "";

        if (index < current.lines.Length)
        {
            foreach (char c in current.lines[index])
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typespeed);
            }
            
        }else{
            print("Fertig");
            // NPC Geht weg
        }

        FinishLine();
    }

    void FinishLine()
    {
        typing = false;
        if (index == current.lines.Length - 1) ShowChoices();
    }

    void SkipTyping() // werden Alle wörter sofort angezeigt
    {
        StopAllCoroutines();
        dialogueText.text = current.lines[index];
        FinishLine();
    }

    void ShowChoices()
    {
        if (current.choices == null || current.choices.Length == 0) return;
        choosing = true;

        foreach (Choice choice in current.choices)
        {
            Button button = Instantiate(choiceButtonPrefab, choiceContainer);
            button.GetComponentInChildren<TMP_Text>().text = choice.text;
            button.onClick.AddListener(()=> PickChoice(choice));
        }
    }

    void PickChoice(Choice choice)
    {
        foreach (Transform child in choiceContainer) Destroy(child.gameObject);
        choosing = false;

        if (choice.text != null) StartDialogue(choice.next);
        else EndDialogue();
    }

    void EndDialogue()
    {
        isTalking = false;
        panel.SetActive(false);
    }

    void NextLine() // schreibt das nächste Element / Dialog text
    {
        index++;
        if (index < current.lines.Length) StartCoroutine(TypeLine());
        else EndDialogue();
    }
}
