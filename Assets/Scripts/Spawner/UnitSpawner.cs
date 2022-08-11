using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sugeng.TapZombie.GameUnit;

namespace Sugeng.TapZombie.Spawner
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] Transform[] spawnPos;
        [SerializeField] WaveData[] waves;

        [Header("Pool Section")]
        [SerializeField] PoolUnit<Unit_BasicHuman> humanPool;
        [SerializeField] PoolUnit<Unit_BasicZombie> zombiePool;

        [SerializeField] Transform humanPos, zombiePos;



        private void Start()
        {
            SpawnWave(waves[Random.Range(0, waves.Length)]);
        }

        void SpawnWave(WaveData waveData)
        {
            if (GameManager.Instance.isGameEnd) return;
            GameManager.Instance.ChangeWave();
            int counterSpawn = 0;
            StartCoroutine(SpawnUnit());
            ////////////-----------------------------
            IEnumerator SpawnUnit()
            {
                while (counterSpawn < waveData.spawnUnitAmount)
                {
                    yield return new WaitForSeconds(1f - (1f * GameManager.Instance.speedMltiper / 3));
                    CreateUnit();
                    counterSpawn++;
                }
                while (GameManager.Instance.unitSpawn < waveData.spawnUnitAmount)
                {
                    yield return null;
                }

                yield return new WaitForSeconds(waveData.delayNextWave);
                SpawnWave(waves[Random.Range(0, waves.Length)]);
            }
            ////////////-----------------------------
            void CreateUnit()
            {
                bool asZombie = Random.Range(1, 101) > 10;
                BaseUnit createdUnit = asZombie ? zombiePool.GetObject() : humanPool.GetObject();
                createdUnit.gameObject.SetActive(true);
                createdUnit.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].position;

                createdUnit.transform.SetParent(asZombie ? zombiePos : humanPos);
            }
        }

        [System.Serializable]
        struct WaveData
        {
            public int spawnUnitAmount;
            public float delayNextWave;
        }

        [System.Serializable]
        public class PoolUnit<T> where T : BaseUnit
        {
            [SerializeField] List<UnitSpawnData> variationUnits;
            public T GetObject()
            {
                T createdUnit;

                var variationTarget = variationUnits[Random.Range(0, variationUnits.Count)];
                if (variationTarget.pool.Count <= 0)
                {
                    createdUnit = Instantiate(variationTarget.unitBaseObject);
                    createdUnit.OnUnitDie += () => { StoreUnit(createdUnit); };
                }
                else
                {
                    createdUnit = variationTarget.pool.Dequeue();
                }

                return createdUnit;
            }

            public void StoreUnit(T unit)
            {
                for (int i = 0; i < variationUnits.Count; i++)
                {
                    if (variationUnits[i].unitBaseObject.GetType() == unit.GetType())
                    {
                        variationUnits[i].pool.Enqueue(unit);
                        return;
                    }
                }
            }

            [System.Serializable]
            class UnitSpawnData
            {
                public T unitBaseObject;
                public Queue<T> pool = new Queue<T>();
            }
        }
    }
}