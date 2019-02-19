﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ag_Character : MonoBehaviour {

	string ag_NextScenename = "Level 3";
	float ag_speed = .15f;
	AudioSource ag_audioSource;
	Animator ag_anim;
	Rigidbody ag_playerRigidbody;
    float ag_rotationSpeed = 180f;
	bool ag_hasSword;
	public GameObject ag_theSword;
	public GameObject ag_theSword_avatar;
	public AudioClip ag_audio_gotItem = null;
	public AudioClip ag_audio_Died;
	public AudioClip ag_audio_win;
	public AudioClip ag_audio_step;
	public string ag_WalkingAxis = "Vertical";
	public string ag_WalkingRotation = "Horizontal"; 

	AudioSource ag_mainCamera_audio;

	enum AG_CharacterState{Alive, Dead, Win};
	AG_CharacterState ag_CharacterState = AG_CharacterState.Alive;
	[SerializeField] ParticleSystem ag_WinParticle1;
	[SerializeField] ParticleSystem ag_WinParticle2;

	void Awake(){
		ag_anim = GetComponent<Animator>();
		ag_playerRigidbody = GetComponent<Rigidbody>();
		ag_audioSource = GetComponent<AudioSource>();
		ag_hasSword = false;
		ag_theSword.SetActive(true);
		ag_theSword_avatar.SetActive(false);

	}

	void FixedUpdate(){
		if(ag_CharacterState == AG_CharacterState.Alive){
			float walkingAxis = Input.GetAxis(ag_WalkingAxis);
			float rotateAxis = Input.GetAxis(ag_WalkingRotation);
			Ag_Move(walkingAxis);
			Ag_Rotate(rotateAxis);
			Ag_Animate(walkingAxis,rotateAxis);
		}
		
	}

	void Ag_Move(float moveInput){
		transform.Translate(Vector3.forward*moveInput*ag_speed);

	}

	private void Ag_Rotate(float rotateInput){
		transform.Rotate(0,rotateInput*ag_rotationSpeed*Time.deltaTime,0);
    }

	void Ag_Animate(float h, float v){
		bool walking = h!= 0f || v!=0f;
		ag_anim.SetBool("IsWalking", walking);
		if(walking){
			if (!ag_audioSource.isPlaying) //doesnt layer
             {
                 ag_audioSource.PlayOneShot(ag_audio_step);
             }
         }
         else
         {
             ag_audioSource.Stop();
	     }
	}

	void OnCollisionEnter(Collision collision){
        switch (collision.gameObject.tag)
        {
            case "Anna_Sword":
				ag_audioSource.PlayOneShot(ag_audio_gotItem);
				ag_hasSword = true;
				ag_theSword.SetActive(false);
				ag_theSword_avatar.SetActive(true);
                //print("Friend");
                break;

            case "Anna_Ending":
				//LoadTheScene("Level 4");
				ag_audioSource.PlayOneShot(ag_audio_win);
				ag_WinParticle2.Play();
				ag_WinParticle1.Play();
				ag_CharacterState = AG_CharacterState.Win;
				ag_anim.SetBool("IsWalking", false);
				//message
				//next scene
                print("Win");
                break;
			case "Anna_Dragon":
				if(ag_hasSword){
					//can go
					print("Keep going");
				}
				else{
					Ag_CharacterDieWithDragon();
				}
				break;
			case "Anna_Hazard":
				Ag_CharacterDie();
				print("Die");
				break;
			case "Anna_Minion":
				Ag_CharacterDieMinion();
				break;
			default:
				break;
        }
      
    }

	private void LoadTheScene(){
		SceneManager.LoadScene(ag_NextScenename, LoadSceneMode.Single);
	}

	public bool Ag_Get_hasSword(){
		return ag_hasSword;
	}

	public void Ag_CharacterDie(){
		ag_CharacterState = AG_CharacterState.Dead;
		ag_audioSource.Stop();
		ag_audioSource.PlayOneShot(ag_audio_Died);
		Invoke("LoadTheScene", 2f);
		ag_anim.SetTrigger("Die");
	}

	public void Ag_CharacterDieWithDragon(){
		ag_CharacterState = AG_CharacterState.Dead;
		ag_audioSource.Stop();
		Invoke("Ag_PlayMusic_and_animation", 0.5f);
		Invoke("LoadTheScene", 3f);
	}

	public void Ag_PlayMusic_and_animation(){
		ag_audioSource.PlayOneShot(ag_audio_Died);
		ag_anim.SetTrigger("Die");
	}

	public void Ag_CharacterDieMinion(){
		ag_CharacterState = AG_CharacterState.Dead;
		ag_audioSource.Stop();
		ag_audioSource.PlayOneShot(ag_audio_Died);
		Invoke("LoadTheScene", 2f);
		ag_anim.SetTrigger("Die");
	}

}