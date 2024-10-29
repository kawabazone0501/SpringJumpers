using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public float followSpeed = 5f;
    public float offsetX = 1f;  // X軸方向のオフセット
    public float offsetY = 1f;  // Y軸方向のオフセット
    public bool isKey = false;

    private Transform playerTransform;
    private float playerDirection;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("触れた");
            // プレイヤーオブジェクトに触れたら追従する
            isKey = true;
            playerTransform = other.transform;
            StartCoroutine(FollowPlayer());
        }
    }

    IEnumerator FollowPlayer()
    {
        while (playerTransform != null)
        {
            // プレイヤーの位置にオフセットを加えて取得
            Vector3 targetPosition = playerTransform.position + new Vector3(offsetX * playerDirection, offsetY, 0f);
            targetPosition.z = transform.position.z; // Z軸の位置を合わせる

            // 追従オブジェクトをプレイヤーに向けて移動
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public bool IsFollowingPlayer()
    {
        return isKey;
    }

    void Update()
    {
        // プレイヤーの向きを取得
        if (playerTransform != null)
        {
            playerDirection = Mathf.Sign(playerTransform.localScale.x);
        }
    }
}
