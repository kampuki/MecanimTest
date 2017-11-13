using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	private Animator animator;

	private Rigidbody rig;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("up")) {

			transform.position += transform.forward * 0.03f;
			animator.SetBool("Walk", true);

		} else {
			animator.SetBool("Walk", false);
		}
		if (Input.GetKey ("right")) {
			transform.Rotate (0, 5, 0);
		}
		if (Input.GetKey ("left")) {
			transform.Rotate (0, -5, 0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			animator.SetTrigger ("JumpTrigger");
		}

	}
}
