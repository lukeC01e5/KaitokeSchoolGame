using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathOfPlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
            freeze();
            StartCoroutine(RestartLevel());
            
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
    }
    public void freeze()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }
    public void unfreeze()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }


    IEnumerator RestartLevel()
    {

        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
