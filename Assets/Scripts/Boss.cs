using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private int maxHeath = 10;
    [SerializeField] private int currentHeath;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHeath);
        currentHeath = maxHeath;
    }

    public void TakeDamage(int value)
    {
        currentHeath -= value;
        healthBar.SetHealth(currentHeath);
        if(currentHeath <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
