// by @torahhorse

// Instructions:
// Place on player. OnBelowLevel will get called if the player ever falls below

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class CheckIfOutside : MonoBehaviour
{
	public Canvas EscCan;
	public GameObject Player;
	private Button ExitButton;
	private Button BackButton;
	private Animator anim;
	Camera m_MainCamera;

	public float resetBelowThisX = -1.5f;
	public bool fadeInOnReset = true;
	public static bool paused = false;

	private Vector3 startingPosition;
	//private Quaternion startingCameraRotation;

	void Awake()	{
		startingPosition = transform.position;
		//startingCameraRotation = Camera.main.transform.rotation;
	}

	void Start() {
		anim = GetComponent<Animator>();
    //Find the object you're looking for
    GameObject o1 = GameObject.Find("EscapeCanvas");
    if(o1 != null){
        //If we found the object , get the Canvas component from it.
        EscCan = o1.GetComponent<Canvas>();
				anim = EscCan.GetComponent<Animator>();
        if(EscCan == null){
            Debug.Log("Could not locate Canvas component on " + o1.name);
        }
    }

		BackButton = GameObject.Find("btn_goBack").GetComponent<Button>();
    ExitButton = GameObject.Find("btn_exit").GetComponent<Button>();
		Player = GameObject.Find("Player");
		m_MainCamera = Camera.main;
}

	void Update () {
		if( transform.position.x < resetBelowThisX )
		{
			OnOutsideLevel();
		}
	}

	private void OnOutsideLevel()	{
		BackButton.onClick.AddListener(GoBack);
		ExitButton.onClick.AddListener(ExitGame);
		//set game as paused
		paused = true;
		Time.timeScale = 1.0f - Time.timeScale;

		m_MainCamera.GetComponent<Blur>().enabled = true;
		m_MainCamera.GetComponent<MouseLook>().enabled = false;
		m_MainCamera.GetComponent<LockMouse>().enabled = false;

		Cursor.visible = true;
		Screen.lockCursor = false;
		Player.GetComponent<MouseLook>().enabled = false;
		Player.GetComponent<FirstPersonDrifter>().enabled = false;

		//EscCan.GetComponent<Canvas> ().enabled = true;
		anim.Play("CanvasOpacity");
		// reset the player
		//transform.position = startingPosition;
	}

	public void GoBack() {
		//fade
		if( fadeInOnReset == true )
		{
			// see if we already have a "camera fade on start"
			CameraFadeOnStart fade = GameObject.Find("Main Camera").GetComponent<CameraFadeOnStart>();
			if( fade != null )
			{
				fade.Fade();
			}
			else
			{
				Debug.LogWarning("CheckIfBelowLevel couldn't find a CameraFadeOnStart on the main camera");
			}
		}

		anim.Play("Idle");

		// reset everything
		paused = false;
		Time.timeScale = 1.0f;
		transform.position = startingPosition;
		//Camera.main.transform.rotation = startingCameraRotation;

		m_MainCamera.GetComponent<Blur>().enabled = false;
		m_MainCamera.GetComponent<MouseLook>().enabled = true;
		m_MainCamera.GetComponent<LockMouse>().enabled = true;

		Cursor.visible = false;
		Screen.lockCursor = true;
		Player.GetComponent<MouseLook>().enabled = true;
		Player.GetComponent<FirstPersonDrifter>().enabled = true;

		EscCan.GetComponent<Canvas> ().enabled = false;
		BackButton.onClick.RemoveListener(GoBack);
	}

	public void ExitGame() {
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
        Application.Quit();
		#endif
	}
}
