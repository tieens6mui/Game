using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;


    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        if (Range <= 15f)
        {
            transform.Translate(Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
        }

    }

}