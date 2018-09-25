using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class ToggleEscMenu : MonoBehaviour {

	public Canvas EscCan;
	public GameObject Player;
	private Button ExitButton;
	private Button BackButton;
	private Animator anim;
	Camera m_MainCamera;
	public static bool paused = false;

	void Start () {
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
		if (Input.GetKeyDown(KeyCode.Escape)) {
			BackButton.onClick.AddListener(ReturnToGame);
			ExitButton.onClick.AddListener(ExitGame);
			if (paused == false) {
				Esc();
			} else {ReturnToGame();}
		}
	}

	private void Esc()	{
		paused = true;
		anim.Play("CanvasOpacity");
		m_MainCamera.GetComponent<Blur>().enabled = true;
		m_MainCamera.GetComponent<MouseLook>().enabled = false;
		m_MainCamera.GetComponent<LockMouse>().enabled = false;
		Cursor.visible = true;
		Screen.lockCursor = false;
		Player.GetComponent<MouseLook>().enabled = false;
		Player.GetComponent<FirstPersonDrifter>().enabled = false;
		//Time.timeScale = 1.0f - Time.timeScale;
	}

	public void ReturnToGame() {
		paused = false;
		anim.Play("Idle");

		m_MainCamera.GetComponent<Blur>().enabled = false;
		m_MainCamera.GetComponent<MouseLook>().enabled = true;
		m_MainCamera.GetComponent<LockMouse>().enabled = true;

		Cursor.visible = false;
		//Screen.lockCursor = true;
		Player.GetComponent<MouseLook>().enabled = true;
		Player.GetComponent<FirstPersonDrifter>().enabled = true;

		EscCan.GetComponent<Canvas> ().enabled = false;

		BackButton.onClick.RemoveListener(ReturnToGame);
	}

	public void ExitGame() {
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
        Application.Quit();
		#endif
	}
}
