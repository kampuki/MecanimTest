using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToFromAHight : MonoBehaviour {

	private Transform rayPosition;
	private float rayRange;
	private float fallPosition;
	private MyHp myHp;
	private bool fallFlag;
	private float distance;
	public float damageDistance;

	// Use this for initialization
	void Start () 
	{
		distance = 0f;
		rayRange = 0.85f;
		fallPosition = transform.position.y;
		fallFlag = false;
		myHp = transform.Find("Hp").GetComponent<MyHp>();
		LineRenderer renderer = gameObject.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (rayPosition.position, rayPosition.position + Vector3.down * rayRange, Color.blue);
		if (Physics.Linecast (rayPosition.position, rayPosition.position + Vector3.down * rayRange, LayerMask.GetMask ("Field", "Block"))) {
			if (fallFlag) {
				distance = fallPosition - transform.position.y;
				if (distance >= damageDistance) {
					myHp.Damage (distance - damageDistance);
				}
				fallFlag = false;
			}
		} else {
			if (!fallFlag) {
				fallPosition = transform.position.y;
				distance = 0;
				fallFlag = true;
			}
		}
		fallPosition = Mathf.Max (fallPosition, transform.position.y);
	}
}
