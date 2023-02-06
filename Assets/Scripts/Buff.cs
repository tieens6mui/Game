using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] private int heath;
    public GameObject collectvfx;
    public int CollectBuff()
    {
        // Sinh ra hieu ung collectVfx
        var colVfx = Instantiate(collectvfx, this.transform.position, this.transform.rotation);
        Destroy(colVfx, 1f); // Detroy doi tuong sau thoi gian delay
        return heath;
    }
}
