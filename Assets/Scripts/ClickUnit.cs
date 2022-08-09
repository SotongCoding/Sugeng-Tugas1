using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickUnit : MonoBehaviour
{
    [SerializeField] float speed = 3;
    public bool asZombie { private set; get; } = true;

    [SerializeField] SpriteRenderer sprite;

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    private void OnMouseDown()
    {
        if (asZombie)
        {
            Destroy(gameObject);
            GameManager.Instance.GainScore(10);
        }
        else
        {
            GameManager.Instance.ReduceHealth(99);

        }
    }

    internal void InitialStatus()
    {
        asZombie = Random.Range(0, 2) >= 1 ? true : false;
        sprite.color = asZombie ? Color.red : Color.green;

        speed = speed + (speed * GameManager.Instance.speedMltiper);
    }
}
