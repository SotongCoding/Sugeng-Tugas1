using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickUnit : MonoBehaviour
{
    [SerializeField] float speed = 3;
    public bool asZombie { private set; get; } = true;

    [SerializeField] SpriteRenderer visual;
    [SerializeField] Sprite[] avaiableSprites;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.down);
    }

    internal void InitialStatus()
    {
        asZombie = Random.Range(0, 101) >= 10 ? true : false; //10% human
        speed = speed + (speed * GameManager.Instance.speedMltiper);

        visual.sprite = avaiableSprites[asZombie ? 0 : 1];
    }
}
