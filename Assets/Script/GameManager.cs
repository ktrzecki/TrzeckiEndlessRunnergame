using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region
    public static GameManager Instance;

    //awake happens before start, set gamemanager to whatever this script is attached to
    public void Awake()
    {
        if (Instance == null) Instance = this;
    }


    #endregion


    public float currentScore = 0f;

    public bool isPlaying = false;

    public string scoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }

        if (Input.GetKeyDown("p"))
        {
            isPlaying = true;
        }

    }

}
