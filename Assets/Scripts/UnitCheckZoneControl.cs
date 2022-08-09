using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCheckZoneControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            if (collision.GetComponent<ClickUnit>().asZombie)
            {
                Debug.Log("Reduce Health");
                GameManager.Instance.ReduceHealth(1);
            }
            else
            {
                Debug.Log("Gain Score for Humman pass");
                GameManager.Instance.GainScore(10);
            }
            GameManager.Instance.unitSpawn++;
            Destroy(collision.gameObject);
        }
    }
}
