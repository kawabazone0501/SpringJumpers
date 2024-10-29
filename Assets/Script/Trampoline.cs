using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 10f; // 跳ねさせる力

    public bool isTramp;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
    // 他のColliderに触れたときに呼び出されるコールバック
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*前のバージョン
        //if (collision.CompareTag("Foot")) // プレイヤータグが設定されている場合
        //{
        //    Debug.Log("触れた");
        //    isTramp = true;
        //    animator.SetBool("isTouchPlayer", true);
        //    Rigidbody2D playerRigidbody = collision.GetComponent<Rigidbody2D>();
        //    if (playerRigidbody != null && isTramp)
        //    {
        //        //プレイヤーに力を加えて跳ねさせる
        //        Vector2 bounceDirection = Vector2.up; // 跳ねる方向（上向き）
        //        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f); // 現在の速度をリセット
        //        playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        //        isTramp = false;
        //    }
        //}*/
        if (collision.CompareTag("Foot")) // プレイヤーの足元にタグを設定
        {
            Debug.Log("トランポリンに触れた");

            Rigidbody2D playerRigidbody = collision.GetComponentInParent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                // 現在の速度をリセットし、上方向に力を加える
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f);
                playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTramp = false;
            animator.SetBool("isTouchPlayer", false); // アニメーションを停止
        }
        //if (collision.CompareTag("Player"))
        //{
        //    // プレイヤーから離れた時の処理
        //    animator.SetBool("isTouchPlayer", false); // アニメーションを停止
        //}

    }

    private void JumpPlayer(Rigidbody2D playerRigidbody)
    {
        if (playerRigidbody != null && isTramp)
        {
            // プレイヤーに力を加えて跳ねさせる
            Vector2 bounceDirection = Vector2.up; // 跳ねる方向（上向き）
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0f); // 現在の速度をリセット
            playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            isTramp = false;
        }
    }

    public void OnTrampoline()
    {
        //JumpPlayer(GetComponent<Rigidbody2D>());
        isTramp = true;
    }

    public void OffTrampoline()
    {
        isTramp = false;
    }
}
