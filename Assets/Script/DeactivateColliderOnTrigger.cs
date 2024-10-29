using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateColliderOnTrigger : MonoBehaviour
{
    public Follower follower; // Followerスクリプトを参照するための変数
    public Animator[] animator; // アニメーションを制御するAnimator

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Followerに触れたらアニメーションを再生する
            if (follower != null && follower.IsFollowingPlayer())
            {
                PlayAnimation();
            }
        }
    }

    void PlayAnimation()
    {
        if (animator != null)
        {
            animator[0].SetTrigger("isOpenKey");
            animator[1].SetTrigger("isOpenWall");
        }
    }
}
