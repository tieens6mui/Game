using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 minMaxPos;
    private Vector2 currentMinMaxPos;
    [SerializeField] private bool isRight;
    [SerializeField] private bool ai;
    private SpriteRenderer sprite;


    [SerializeField] private int score;
    [SerializeField] private GameObject collectVfx;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentMinMaxPos = new Vector2(transform.position.x - minMaxPos.x, transform.position.x + minMaxPos.y);
        sprite = GetComponent<SpriteRenderer>();
    }
  
    public int CollectEnemy()
    {
        // Sinh ra hieu ung collectVfx
        var colVfx = Instantiate(collectVfx, this.transform.position, this.transform.rotation);
        Destroy(colVfx, 1f); // Detroy doi tuong sau thoi gian delay
        return score;
    }
    private void Update()
    {
        if (!ai) return;
        if (isRight)
        {
            rigid.velocity = new Vector2(speed * Time.fixedDeltaTime, rigid.velocity.y);
        }
        else
        {
            rigid.velocity = new Vector2(-speed * Time.fixedDeltaTime, rigid.velocity.y);
        }

        if (transform.position.x < currentMinMaxPos.x)
        {
            isRight = true;
            sprite.flipX = false;
        }
        else if (transform.position.x > currentMinMaxPos.y)
        {
            isRight = false;
            sprite.flipX = true;
        }
    }
}
