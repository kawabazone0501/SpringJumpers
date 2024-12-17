using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    Transform target;
    Vector3 fixedPosition;
    bool isFollowing = true;
    public Vector3 stopFollowingPosition; // 特定の座標

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーの座標取得
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fixedPosition = transform.position; // カメラの初期位置を保存
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            // プレイヤーが特定の座標に達したら追従を止める
            if (target.position.x < stopFollowingPosition.x && target.position.y < stopFollowingPosition.y)
            {
                stopFollowingPosition.y = target.position.y;
                isFollowing = false;
            }
            else
            {
                // カメラの位置をプレイヤーに追従
                Camera.main.transform.position = new Vector3(target.transform.position.x,
                                                             target.transform.position.y + 2,
                                                             -10);
            }
        }
        else
        {
            // カメラの位置を固定
            Camera.main.transform.position = new Vector3(fixedPosition.x, fixedPosition.y, -10);

            // プレイヤーが特定の座標に戻ったら再び追従を開始
            if (target.position.x >= stopFollowingPosition.x)
            {
                isFollowing = true;
            }
        }
    }
}
