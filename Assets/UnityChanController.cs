using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnityChanController : MonoBehaviour {

	private Animator animator;

	private Rigidbody rig;

	public MyHp myHp;

	int hpCount;

	private bool isLButtonDown;

	private bool isRButtonDown;

	private bool isGoButtonDown;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator> ();

		rig = GetComponent<Rigidbody> ();

		myHp = transform.Find ("Hp").GetComponent<MyHp> ();







	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("up") || isGoButtonDown) {

			transform.position += transform.forward * 0.03f;

		}
		if (Input.GetKey ("right") || isRButtonDown) {
			transform.Rotate (0, 5, 0);
		}
		if (Input.GetKey ("left") || isLButtonDown) {
			transform.Rotate (0, -5, 0);
		}
			

		hpCount = myHp.GetHpCount ();
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Goal" && hpCount == 7) {
			SceneManager.LoadScene ("GoalScene");
		}

		if (col.gameObject.tag == "Goal" && hpCount != 7) {
			SceneManager.LoadScene ("GameoverScene");
		}

	}

	public void RButtonDown() {
		isRButtonDown = true;
	}

	public void RButtonUp() {
		isRButtonDown = false;
	}

	public void LButtonDown() {
		isLButtonDown = true;
	}

	public void LButtonUp() {
		isLButtonDown = false;
	}
			

	public void GoButtonDown() {
		isGoButtonDown = true;
	}

	public void GoButtonUp() {
		isGoButtonDown = false;
	}
}
