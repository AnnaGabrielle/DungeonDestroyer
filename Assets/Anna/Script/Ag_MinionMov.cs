using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ag_MinionMov : MonoBehaviour {

	[Range(0.1f,100)][SerializeField] float ag_period =20f;
	[SerializeField] Vector3 ag_movementVector;
	[SerializeField] Vector3 ag_StartPosition;
	[SerializeField] Vector3 ag_EndingPosition; 

	Vector3 ag_distanceP = new Vector3(0,0,0);
	
	[SerializeField] float ag_MinionVel=.15f;
	Vector3 ag_MinionVelVec;

	[Range(0,1)][SerializeField]float ag_movementeFactor=0; //0 not, 1 fully
	// Use this for initialization

	Vector3 ag_StartingPos;
	void Start () {
		ag_StartingPos = transform.position;
	}
	
	// Update is called once per frame

	void Update(){
		AG_MovMinion();
		if(ag_distanceP.x >= ag_movementVector.x && ag_distanceP.y >= ag_movementVector.y && ag_distanceP.z >= ag_movementVector.z){
			ag_distanceP = new Vector3 (0,0,0);
			AG_RotateMinion();
		}

	 }

	// void Update () {

	// 	if(ag_movementeFactor > 0.99998f || ag_movementeFactor < 0.00001f){
	// 		AG_MovMinion();
	// 	}
	// 	float ag_cycles = Time.time / ag_period;
	// 	const float tau = Mathf.PI * 2;
	// 	float rawSinWave = Mathf.Sin(ag_cycles*tau);
	// 	ag_movementeFactor = rawSinWave/2f + 0.5f;
	// 	Vector3 ag_offset = ag_movementeFactor * ag_movementVector;
	// 	transform.position = ag_StartingPos + ag_offset;
	// }

	public void AG_MovMinion(){
		Vector3 ag_offset = Vector3.forward * ag_MinionVel;
		transform.Translate(ag_offset);
		ag_distanceP += ag_offset;
		
	}
	public void AG_RotateMinion(){
			transform.Rotate(0,180f,0);
	}
}
