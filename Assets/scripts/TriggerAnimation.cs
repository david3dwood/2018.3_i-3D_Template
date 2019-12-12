using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour {
	
	public AudioSource someSound;
	public string ThingToAnimate;
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
            anim.SetTrigger("1"); 
			GetComponent<Animation>().Play(ThingToAnimate); 
			someSound.Play();		
		}
	}

}

