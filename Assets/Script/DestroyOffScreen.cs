using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{

    [SerializeField] private float leftBound = -11f;
    [SerializeField] private float rightBound = 5f;

    private void Update()
    {
        if(transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

        if(transform.position.x < rightBound)
        {
            Destroy(gameObject);
        }
    }
}
