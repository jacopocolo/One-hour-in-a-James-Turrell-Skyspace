using UnityEngine;
﻿using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

  public Animator animator;

  public void FadeToLevel() {
    animator.SetTrigger("FadeOut");
  }

  public void OnFadeComplete() {
     Cursor.visible = false;
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
  }

}
