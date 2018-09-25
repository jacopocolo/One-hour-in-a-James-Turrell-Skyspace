using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorVisible : MonoBehaviour {
	void Start () {
		Cursor.visible = true;
		Screen.lockCursor = false;
	}
}
