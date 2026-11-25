using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class DialogueData : ScriptableObject
{
    public string speakername;
    [TextArea] public string[] lines;
    public Choice[] choices;

}

[System.Serializable]

public class Choice
{
    public string text;
    public DialogueData next;
}