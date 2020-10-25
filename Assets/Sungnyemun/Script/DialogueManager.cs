using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;

  private Queue<string> sentences;
    
    public void StartDialogue (Dialogue dialogue)
    {
        if (sentences == null) sentences = new Queue<string>();
        Debug.Log(dialogue.sentences.Length);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); 
        }
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    

        void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}

 