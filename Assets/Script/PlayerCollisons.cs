using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisons : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            //TODO connect this to a game manager GameOver()
        }
    }
}
