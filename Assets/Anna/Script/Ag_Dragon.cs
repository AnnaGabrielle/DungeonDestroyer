using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ag_Dragon : MonoBehaviour {

	Ag_Character ag_Character;
	Animation dragon_anim;
	
	public AudioClip audio_deathDragon =null;
	public AudioClip audio_DragonKill=null;
	AudioSource ag_audioSource;

	// Use this for initialization
	void Start () {
		ag_Character = GameObject.FindGameObjectWithTag("Anna_Character").GetComponent<Ag_Character>();
		dragon_anim = GetComponent<Animation>();
		ag_audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collision){
		bool hasSword = ag_Character.Ag_Get_hasSword();
		if(hasSword){ //element 1
			ag_audioSource.PlayOneShot(audio_deathDragon);
			dragon_anim.Play("sj001_die");
			Destroy(gameObject, 3.5f);
			//soundeffect
			//particles
			
		}
		else{ //skill2 element 3
			ag_audioSource.PlayOneShot(audio_DragonKill);
			dragon_anim.Play("sj001_skill2");
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
