using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // private AudioSource finishSound;
    private Rigidbody2D rb2;

    private bool levelCompleted = false;

    private void Start()
   {
        rb2 = GetComponent<Rigidbody2D>();
        //finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.name == "Player" && !levelCompleted)
        if(collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            //finishSound.Play();
            levelCompleted = true;
            //Invoke("CompleteLevel", 2f);
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}