using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    [Header("Input Dialogue Name")]
    public string dialogueName = "empty";

    [Header("Enter Dialogue's Index")]
    public int dialogueIndex = -1;

    [Header("DialogueChoice = n, f, t")]
    public char dialogueChoice = 'x';
}
