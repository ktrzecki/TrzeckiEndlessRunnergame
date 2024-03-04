using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UI_Script : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    GameManager gameManager;

    [SerializeField] private GameObject buttonStartGame;
    [SerializeField] private GameObject buttonLoseText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreDisplay.text = ("score ") + gameManager.scoreDisplay();
    }
    public void StartGame()
    {
        //buttonLoseText.gameObject.SetActive(false);
        buttonStartGame.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        //buttonLoseText.gameObject.SetActive(true);
        buttonStartGame.gameObject.SetActive(true);
    }

}
