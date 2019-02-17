﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//change name later! AG_name
public class Rocket : MonoBehaviour {

	// Rigidbody rocketRidigbody;
    // AudioSource audioStep;
    // [Range(50,300)][SerializeField] float rcsThrust = 100f;
    // [SerializeField] float mainThrust = 100f;
    // // Use this for initialization
    // void Start () {
	// 	rocketRidigbody = GetComponent<Rigidbody>();
    //     audioStep = GetComponent<AudioSource>();
	// }
	
	// // Update is called once per frame
	// void Update () {
    //     Trust();
    //     Rotate();
	// }

	// private void Rotate()
    // {
    //     rocketRidigbody.freezeRotation = true; //take manual control of rotation
    //     float rotationThisFrame = rcsThrust * Time.deltaTime; // frame time
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         transform.Rotate(Vector3.forward * rotationThisFrame); //anti-clock
    //     }
    //     else if (Input.GetKey(KeyCode.D))
    //     {
    //         transform.Rotate(-Vector3.forward * rotationThisFrame); //clock wise
    //     }
    //     rocketRidigbody.freezeRotation = false;

    // }

    // private void Trust() //go foward on mine, use the 
    // {
    //     if (Input.GetKey(KeyCode.Space))
    //     {
    //         rocketRidigbody.AddRelativeForce(Vector3.up * mainThrust);
    //         if (!audioStep.isPlaying) //doesnt layer
    //         {
    //             audioStep.Play();
    //         }
    //     }
    //     else
    //     {
    //         audioStep.Stop();
    //     }
    // }

    // void OnCollisionEnter(Collision collision)
    // {
    //     switch (collision.gameObject.tag)
    //     {
    //         case "Anna_Friendly":
    //             print("Friend");
    //             break;

    //         default:
    //             print("Diiiie");
    //             break;
    //     }
      
    // }

}