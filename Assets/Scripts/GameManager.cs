using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        isGameEnd = false;
    }


    public int currentPlayerHealth { private set; get; } = 3;
    public int currentPlayerScore { private set; get; } = 0;
    public bool isGameEnd { private set; get; } = false;
    public float speedMltiper = 1;


    void GameOver()
    {
        isGameEnd = true;
        Debug.Log("Game Over Bro");
    }

    public void ReduceHealth(int amount)
    {
        currentPlayerHealth -= Mathf.Abs(amount);
        if (currentPlayerHealth <= 0)
        {
            GameOver();
        }
    }
    public void GainScore(int scoreGet)
    {
        currentPlayerScore += scoreGet;
    }
}
