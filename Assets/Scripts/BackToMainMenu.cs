using UnityEngine;
﻿using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {

  public void FadeToLevel() {
    if (Time.timeScale > 1.0F) {Time.timeScale = 1.0F;}
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
  }

}
