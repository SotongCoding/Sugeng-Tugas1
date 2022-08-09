using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
        isGameEnd = false;
    }


    public int currentPlayerHealth { private set; get; } = 3;
    public int currentWave { private set; get; } = 0;
    public int currentPlayerScore { private set; get; } = 0;
    public int unitSpawn = 0;

    public bool isGameEnd { private set; get; } = false;
    public float speedMltiper => 0.2f * currentWave;

    [Header("UI-Section")]
    [SerializeField] Image[] healthBars;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;


    public void GameOver()
    {
        isGameEnd = true;
        Debug.Log("Game Over Bro");
    }

    public void ReduceHealth(int amount)
    {
        currentPlayerHealth -= Mathf.Abs(amount);
        healthBars[currentPlayerHealth].gameObject.SetActive(false);

        if (currentPlayerHealth <= 0) GameOver();
    }
    public void GainScore(int scoreGet)
    {
        currentPlayerScore += scoreGet;
        scoreText.text = "Score : \n" + currentPlayerScore.ToString();
    }

    public void ChangeWave()
    {
        currentWave++;
        waveText.text = "Wave : " + currentWave.ToString();
    }
}
