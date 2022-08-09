using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos;
    [SerializeField] ClickUnit unitPrefabs;

    [SerializeField] WaveData[] waves;


    private void Start()
    {
        SpawnWave(waves[Random.Range(0, waves.Length)]);
    }

    void SpawnWave(WaveData waveData)
    {
        if (GameManager.Instance.isGameEnd) return;
        GameManager.Instance.speedMltiper += 0.3f;
        int counterSpawn = 0;
        StartCoroutine(SpawnUnit());

        IEnumerator SpawnUnit()
        {
            while (counterSpawn < waveData.spawnUnitAmount)
            {
                yield return new WaitForSeconds(1f);
                CreateUnit();
                counterSpawn++;
            }

            yield return new WaitForSeconds(waveData.delayNextWave);
            SpawnWave(waves[Random.Range(0, waves.Length)]);
        }

        void CreateUnit()
        {
            var createdUnit = Instantiate(unitPrefabs, spawnPos[Random.Range(0, spawnPos.Length)].position, Quaternion.identity);
            createdUnit.InitialStatus();
        }
    }

    [System.Serializable]

    struct WaveData
    {
        public int spawnUnitAmount;
        public float delayNextWave;
    }
}
