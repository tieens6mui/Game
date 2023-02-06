using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private GameObject collectVfx;

    public int CollectItem()
    {
        // Sinh ra hieu ung collectVfx
        var colVfx = Instantiate(collectVfx, this.transform.position, this.transform.rotation);
        Destroy(colVfx, 1f); // Detroy doi tuong sau thoi gian delay
        return score;
    }

}
