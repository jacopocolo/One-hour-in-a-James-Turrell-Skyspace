// by @torahhorse

// Instructions:
// Place on player. OnBelowLevel will get called if the player ever falls below

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CheckIfSitting : MonoBehaviour
{
	public float sitAboveThisY = 1.1f;
	public Animator anim;
	// private float standingPosition = 0.75f;
	// private float sittingPosition = 0.5f;
	private bool sitting = false;
	private GameObject Player;
	//private Camera m_MainCamera;

	// private Vector3 startingPosition;
	//
	// void Awake()	{
	// 	startingPosition = transform.position;
	// }

	void Start() {
		anim = GetComponent<Animator>();
		Player = GameObject.Find("Player");
		//m_MainCamera = Camera.main;
	}

	void Update () {
		if(Player.transform.position.y > sitAboveThisY)
		{
			SitDown();
		} else {
				GetUp();
		}
	}

	private void SitDown()	{
		if (sitting == false) {
		Debug.Log("sitting at "+ Player.transform.position.y);
		anim.Play("SitDown");
		sitting = true;
		}
	}

	private void GetUp() {
		if (sitting == true) {
		Debug.Log("standing at "+ Player.transform.position.y);
		anim.Play("GetUp");
		sitting = false;
		}
	}
}
