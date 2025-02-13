using UnityEngine;

public class CallAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
   
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CallingAnimationChoice(int choiceNumber)
    {
        switch (choiceNumber)
        {
            case 1:
                animator.SetBool("isDown_1",true); 
                break;
            case 2:
                animator.SetBool("isDown_2", true);
                break;
            case 3:
                animator.SetBool("isDown_3", true);
                break;
            default:
                Debug.Log("アニメーションを呼べない値が入力されています");
                break;
        }
    }

    public void TerminateAnimationChoice(int choiceNumber)
    {
        switch(choiceNumber)
        {
            case 1:
                animator.SetBool("isDown_1", false);
                break;
            case 2:
                animator.SetBool("isDown_2", false);
                break;
            case 3:
                animator.SetBool("isDown_3", false);
                Debug.Log("扉は開く");
                break;
            default:
                Debug.Log("アニメーションを呼べない値が入力されています");
                break;
        }
    }
}
