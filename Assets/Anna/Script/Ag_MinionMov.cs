using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Ag_MinionMov : MonoBehaviour {

	[Range(0.1f,100)][SerializeField] float ag_period =20f;
	[SerializeField] Vector3 Ag_movementVector;
	
	[Range(0,1)][SerializeField]float ag_movementeFactor; //0 not, 1 fully
	// Use this for initialization

	Vector3 ag_StartingPos;
	void Start () {
		ag_StartingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(ag_movementeFactor > 0.99998f || ag_movementeFactor < 0.00001f){
			AG_MovMinion();
		}
		float ag_cycles = Time.time / ag_period;
		const float tau = Mathf.PI * 2;
		float rawSinWave = Mathf.Sin(ag_cycles*tau);
		ag_movementeFactor = rawSinWave/2f + 0.5f;
		Vector3 ag_offset = ag_movementeFactor * Ag_movementVector;
		transform.position = ag_StartingPos + ag_offset;
	}


	public void AG_MovMinion(){
			transform.Rotate(0,180f,0);
	}
}
