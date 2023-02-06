using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopCollider : MonoBehaviour
{
    [SerializeField] private int score;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<Player>().AddScore(this.score);
           
            Destroy(this.transform.parent.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
