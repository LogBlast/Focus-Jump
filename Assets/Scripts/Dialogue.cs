using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string nom;

    [TextArea(3,10)]
    public string [] phrase;
}
