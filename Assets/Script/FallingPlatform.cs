using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1.0f; // 落下までの待機時間

    private Rigidbody2D rb2d;
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true; // 最初は物理挙動を無効にする
    }

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            fallDelay -= Time.deltaTime;

            if (fallDelay <= 1)
            {
                Fall();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false; // 物理挙動を有効にして落下させる
        GetComponent<Collider2D>().enabled = false; // Colliderを無効にして通り抜けさせる（任意）
    }
}
