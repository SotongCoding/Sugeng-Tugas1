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
        Time.timeScale = 1;
        // Ada Kesalahan untuk Branch Tugas 3 LOL
    }


    public int currentPlayerHealth { private set; get; } = 3;
    public int currentWave { private set; get; } = 0;
    public int currentPlayerScore { private set; get; } = 0;
    public int unitSpawn;

    public int unitKilled { private set; get; }
    public int survivedHuman { private set; get; }


    public bool isGameEnd { private set; get; } = false;
    public float speedMltiper => 0.2f * currentWave;

    [Header("UI-Section")]
    [SerializeField] UI_GameUIControl uiGameControl;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Sugeng.TapZombie.Utils.Ray2D.RayObjectManager.RayObject2D(Input.mousePosition);
        }
    }

    public void GameOver()
    {
        isGameEnd = true;
        uiGameControl.ShowGameOverUI();
        Time.timeScale = 0;
    }
    public void ReduceHealth(int amount = 1)
    {
        currentPlayerHealth -= Mathf.Abs(amount);
        uiGameControl.ChangeHealthBar(currentPlayerHealth);
        if (currentPlayerHealth <= 0) GameOver();
    }
    public void GainScore()
    {
        currentPlayerScore += 10 +
                (survivedHuman / 3) +
                (unitKilled / 7);

        uiGameControl.ChangeScoreText(currentPlayerScore);
    }
    public void AddUnitKilled()
    {
        unitKilled++;
        uiGameControl.ChangeZombiKilledText(unitKilled);
    }
    public void AddSurvivedUnit()
    {
        survivedHuman++;
        uiGameControl.ChangeUnitSurviveText(survivedHuman);
    }
    public void ChangeWave()
    {
        currentWave++;
        uiGameControl.ChangeWaveText(currentWave);
    }
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
