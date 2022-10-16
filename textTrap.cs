using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textTrap : MonoBehaviour
{
    public deathOfPlayer stopP;
    public Dialogue dialogue;

    //public Animator animator1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

        }
        
    }
}
  