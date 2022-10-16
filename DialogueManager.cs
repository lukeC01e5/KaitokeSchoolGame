using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{

	//private float delayTime;
	
	public Text dialogueText;
	public deathOfPlayer stopP;
	public Animator animator1;
	//public Animator animator2;

	private Queue<string> sentences;

	void Start()
	{
		sentences = new Queue<string>();
	}
	public void StartDialogue(Dialogue dialogue)
	{
		
		//stopP = GameObject.Find("player").GetComponent<deathOfPlayer>();
		//stopP.freeze();
		

		animator1.SetBool("IsOpen", true);
		


		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		
		if (sentences.Count == 0)
		{
			EndDialogue();
			//StartCoroutine(DelayDialogue(delayTime));
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		animator1.SetBool("IsOpen", false);
	

		//stopP = GameObject.Find("player").GetComponent<deathOfPlayer>();
		//stopP.unfreeze();
	}
	

	

}
