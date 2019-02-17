﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ag_Character : MonoBehaviour {

	Quaternion ag_targetRotation;
	public float ag_speed = 12f;
	AudioSource audioStep;
	Vector3 ag_movement;
	Animator ag_anim;
	Rigidbody ag_playerRigidbody;
	int floorMark;
	float ag_camRayLength = 100f;
	[Range(50,300)][SerializeField] float rcsThrust = 100f;
    float ag_rotationSpeed = 75f;

	void Awake(){
		floorMark = LayerMask.GetMask("Floor");
		ag_anim = GetComponent<Animator>();
		ag_playerRigidbody = GetComponent<Rigidbody>();
		audioStep = GetComponent<AudioSource>();
	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Ag_Move(h, v);
		//Ag_Turning();
		Ag_Animate(h,v);
		//Ag_Rotate();
		
	}

	void Ag_Move(float h, float v){
		ag_movement.Set(h, 0f, v);
		ag_movement = ag_movement.normalized * ag_speed * Time.deltaTime;
		ag_playerRigidbody.MovePosition(transform.position + ag_movement);

	}

	public Quaternion Ag_targetRotation{
		get{return ag_targetRotation;}
	}

	void Ag_Turning(){ //fazer na mao mesmo 
		// Ray ag_camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		// RaycastHit ag_floorHit;
		// if(Physics.Raycast(ag_camRay, out ag_floorHit, ag_camRayLength, floorMark)){
		// 	Vector3 ag_playerToMouse = ag_floorHit.point - transform.position;
		// 	ag_playerToMouse.y = 0f;
		// 	Quaternion newRotation = Quaternion.LookRotation(ag_playerToMouse);
		// 	ag_playerRigidbody.MoveRotation(newRotation);}

		
	}
	private void Ag_Rotate()
    {
		ag_playerRigidbody.freezeRotation = true; //take manual control of rotation
		float ag_rotation = Input.GetAxis("Horizontal");
		ag_rotation *= Time.deltaTime;
		transform.Rotate(0, ag_rotation, 0);
		ag_playerRigidbody.freezeRotation = false; //take manual control of rotation
        // float rotationThisFrame = rcsThrust * Time.deltaTime; // frame time
        // if (Input.GetKey(KeyCode.S))
        // {
		// 	if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)){
        //     transform.Rotate(Vector3.up * rotationThisFrame); //anti-clock
		// 	}
        // }
        // else if (Input.GetKey(KeyCode.W))
        // {
		// 	if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)){
        //     transform.Rotate(-Vector3.up * rotationThisFrame); //clock wise

		// 	}
        // }
        // ag_playerRigidbody.freezeRotation = false;

    }

	void Ag_Animate(float h, float v){
		bool walking = h!= 0f || v!=0f;
		ag_anim.SetBool("IsWalking", walking);
		if(walking){
			if (!audioStep.isPlaying) //doesnt layer
             {
                 audioStep.Play();
             }
         }
         else
         {
             audioStep.Stop();
	     }
	}

}