using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehavior : MonoBehaviour
{
    public string[] lines;

    public float SpeedText;

    public Text dialogueText;
    public GameObject Keys;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void scipTextClick()
    {
        if (dialogueText.text == lines[index])
        {
            NextLines();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];
        }
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(SpeedText);
        }
    }

    public void NextLines()
    {
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = String.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if(Keys != null)
                Keys.SetActive(true);
        }
    }
    
}
