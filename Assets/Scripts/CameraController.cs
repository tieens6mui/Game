using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private MeshRenderer bg;

    // Update is called once per frame
    void Update() // sau khoang 0.12s thi goi mot lan
    {
        // Thay doi gia tri offset cua material
        bg.material.mainTextureOffset += new Vector2(player.inputAxis/2 * Time.deltaTime, 0f);
    }
    private void LateUpdate()
    {
        // di chuyen camera theo player
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
