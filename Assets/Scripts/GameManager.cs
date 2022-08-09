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
    [SerializeField] Image[] healthBars;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI unitKilledText;
    public TextMeshProUGUI unitSurvivedText;

    public GameObject GameOverUI;


    private void Update()
    {
        RayObject();
    }

    void RayObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenPointToRay(Input.mousePosition));
            //make sure you have a camera in the scene tagged as 'MainCamera'
            var hitm = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hitm.collider.TryGetComponent<ClickUnit>(out var getUnit))
            {
                if (getUnit.asZombie)
                {
                    Destroy(getUnit.gameObject);

                    GainScore();
                    AddUnitKilled();
                }
                else
                {
                    GameOver();

                }
                unitSpawn++;
            }
        }
    }

    public void GameOver()
    {
        isGameEnd = true;
        Debug.Log("Game Over Bro");
        GameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReduceHealth(int amount)
    {
        currentPlayerHealth -= Mathf.Abs(amount);
        healthBars[currentPlayerHealth].gameObject.SetActive(false);

        if (currentPlayerHealth <= 0) GameOver();
    }
    public void GainScore()
    {
        currentPlayerScore += 10 +
                (survivedHuman / 3) +
                (unitKilled / 7);
        scoreText.text = currentPlayerScore.ToString();
    }
    public void AddUnitKilled()
    {
        unitKilled++;
        unitKilledText.text = "Kill : " + unitKilled.ToString();
    }
    public void AddSurvivedUnit()
    {
        survivedHuman++;
        unitSurvivedText.text = "Survive :" + survivedHuman.ToString();
    }
    public void ChangeWave()
    {
        currentWave++;
        waveText.text = "Wave : " + currentWave.ToString();
    }
    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
