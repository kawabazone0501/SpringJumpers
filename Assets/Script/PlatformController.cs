using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //プレイヤーをこのオブジェクトの子要素にする
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //プレイヤーの親要素を解除する
            collision.gameObject.transform.SetParent(null);
        }
    }
}
