using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ag_Camera : MonoBehaviour {

	public Transform ag_target;
	public float ag_smotthing = 5f;
	Vector3 ag_offset;
	void Start(){
		ag_offset = transform.position - ag_target.position;

	}

	void FixedUpdate(){
		Vector3 ag_targetCamPos = ag_target.position + ag_offset;
		transform.position = Vector3.Lerp(transform.position, ag_targetCamPos, ag_smotthing*Time.deltaTime);
		

	}
}
