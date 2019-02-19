using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ag_MoveWall : MonoBehaviour {

	[Range(0.1f,100)][SerializeField] float ag_period_Wall =20f;
	[SerializeField] Vector3 ag_movementVector;

	[Range(0,1)][SerializeField]float ag_movementeFactor=0; //0 not, 1 fully
	// Use this for initialization

	Vector3 ag_StartingPos;

	void Start () {
		ag_StartingPos = transform.position;
	}


	void Update () {

		float ag_cycles = Time.time / ag_period_Wall;
		const float tau = Mathf.PI * 2;
		float rawSinWave = Mathf.Sin(ag_cycles*tau);
		ag_movementeFactor = rawSinWave/2f + 0.5f;
		Vector3 ag_offset = ag_movementeFactor * ag_movementVector;
		transform.position = ag_StartingPos + ag_offset;
	}

	


}
