using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

public class UI_GameUIControl : MonoBehaviour
{
    [Header("UI-Section")]
    [SerializeField] Image[] healthBars;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI unitKilledText;
    public TextMeshProUGUI unitSurvivedText;

    public GameObject GameOverUI;

    public void ChangeHealthBar(int currentPlayerHP)
    {
        healthBars[currentPlayerHP].gameObject.SetActive(false);

    }

    public void ShowGameOverUI()
    {
        GameOverUI.SetActive(true);
    }

    public void ChangeScoreText(int currentScore)
    {
        scoreText.text = currentScore.ToString();
    }
    public void ChangeWaveText(int currentWave)
    {
        waveText.text = "Wave : " + currentWave.ToString();
    }
    public void ChangeZombiKilledText(int currentZombieKilled)
    {
        unitKilledText.text = "Kill : " + currentZombieKilled.ToString();
    }
    public void ChangeUnitSurviveText(int currentHumanSurvive)
    {
        unitSurvivedText.text = "Survive : " + currentHumanSurvive.ToString();
    }
}
