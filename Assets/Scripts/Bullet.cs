using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public float speed;
    [SerializeField] private int score;
    private bool isRight;
  

    public Action<int> OnTrigger; // AddScore
  
    private void Update()
    {
        if(isRight)
            transform.position += Vector3.right * speed * Time.deltaTime;
        else
            transform.position += Vector3.left * speed * Time.deltaTime;
    }
   
    public int CollectBullet()
    {

        return score;
    }
 
  
    public void SetRotate(bool isRight)
    {
        this.isRight = isRight;
    }


    
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
            OnTrigger?.Invoke(score);
        }
        if(col.collider.CompareTag("Boss"))
        {
            Destroy(gameObject);
            Boss boss = col.transform.GetComponent<Boss>();
            boss.TakeDamage(1);
        }
    }
    
}



