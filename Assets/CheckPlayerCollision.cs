using UnityEngine;
using System.Collections;

public class CheckPlayerCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision col)
    {

        if(col.gameObject.name == "Player")
        {
					Debug.Log("hit: "+Time.frameCount);
        }
    }
}
