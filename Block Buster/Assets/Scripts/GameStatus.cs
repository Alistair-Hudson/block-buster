using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //Paramters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int basePointsPerBlock = 83;
    [SerializeField] Text scoreText;
    [SerializeField] bool isAutoPlay;
    float scoreTick = 1;

    // State Variables
    [SerializeField] int gameScore = 0;
    bool hasStarted = false;

    // Create Singleton of Game Status to retain score between levels
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (0 <= gameSpeed && 
            0 >= (scoreTick -= Time.deltaTime) && 
            hasStarted)
        {
            ++gameScore;
            scoreTick = 1;
        }
        Time.timeScale = gameSpeed;
        scoreText.text = gameScore.ToString();

    }

    public void AddPoints(int points = 50)// Base Points per block
    {
        gameScore += points;
    }

    public int GetScore()
    {
        return gameScore;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlay()
    {
        return isAutoPlay;
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }

    public void SetHasStarted(bool state)
    {
        hasStarted = state;
    }

    public void SetGameSpeed(float newGameSpeed)
    {
        gameSpeed = newGameSpeed;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
        SetGameSpeed(0);
    }
}
