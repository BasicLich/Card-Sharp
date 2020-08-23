using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    void OnTriggerEnter2D() {
        TriggerDialogue();
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
}
