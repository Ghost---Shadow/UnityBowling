﻿using UnityEngine;
using System.Collections;

public class BallThrower : MonoBehaviour {

	public float _power = 0;
	public float _throw = 20;
	bool thrown = false;
	bool throwHasStarted = false;
	int  maxLaneWidth = 1;
	int  minLaneWidth = -1;
	bool increasingWidth = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			throwHasStarted = true;
			_power += _throw * Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			StartCoroutine(ThrowBall());		
		}
		if (!throwHasStarted) {
			SetUpBallLocation ();
		}
	}

	void SetUpBallLocation() {
		Vector3 offset = new Vector3(0.04f, 0, 0);
		if (increasingWidth) {
			this.transform.position += offset;
			if (this.transform.position.x > maxLaneWidth) {	
				increasingWidth = false;
				this.transform.position -= offset;
			}
		} else if (!increasingWidth) {
			this.transform.position -= offset;
			if (this.transform.position.x < minLaneWidth) {	
				increasingWidth = true;
				this.transform.position += offset;
			}
		}
//		transform.rotation = transform.rotation * Quaternion.Euler(0f, 01f, 0f);
	}


	public IEnumerator ThrowBall() {
		if (!thrown) {
			//Do not throw anymore
			thrown = true; 
			//Rotate the throw by the rotation angle
			rigidbody.velocity = transform.forward * _power;
			yield return 0;
		}
	}
}
