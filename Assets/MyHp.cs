﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHp : MonoBehaviour {

	private int hp;
	private int oldHp;
	private Text hpText;


	// Use this for initialization
	void Start () 
	{
		hp = 100;
		oldHp = hp;
		hpText = GetComponentInChildren<Text> ();
		hpText.text = hp.ToString ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hp != oldHp) {
			hpText.text = hp.ToString ();
			oldHp = hp;
		}
	}

	public void Damage(int damage) {
		hp -= damage;
		hpText.text = hp.ToString ();
		oldHp = hp;
	}
}
