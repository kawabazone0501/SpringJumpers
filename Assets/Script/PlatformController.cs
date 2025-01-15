using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーをこのオブジェクトの子要素にする
            collision.gameObject.transform.SetParent(transform);

            // Rigidbody2DをKinematicにする
            //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            //if (rb != null)
            //{
            //    rb.isKinematic = true;
            //    rb.velocity = Vector2.zero; // 速度をリセット
            //}
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーの親要素を解除する
            collision.gameObject.transform.SetParent(null);

            // Rigidbody2Dを元に戻す
            //Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            //if (rb != null)
            //{
            //    rb.isKinematic = false;
            //}
        }
    }
}
