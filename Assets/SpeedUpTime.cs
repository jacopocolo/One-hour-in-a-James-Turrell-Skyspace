using UnityEngine;
using System.Collections;

public class SpeedUpTime : MonoBehaviour {
  public float multiplier = 10.0F;
    void Update() {
        if (Input.GetKey("f")) {
            if (Time.timeScale == 1.0F) {
              Time.timeScale = multiplier;
                } else {
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            }
        }
    }
}
