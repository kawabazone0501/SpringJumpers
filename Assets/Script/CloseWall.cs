using UnityEngine;

public class CloseWall : MonoBehaviour
{
    [SerializeField]  CallAnimation callAnimation;

    [SerializeField] private int CallingNumber = 0;

    private bool isClose = false;
    private bool isOpen = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isClose)
        {
            Debug.Log("判定に触れた");
            isClose = true;
            callAnimation.CallingAnimationChoice(CallingNumber);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!isOpen)
        {
            Debug.Log("判定から出た");
            isOpen = true;
            callAnimation.TerminateAnimationChoice(CallingNumber);
            BoolReset();
        }
    }

    public void BoolReset()
    {
        Debug.Log("bool値のリセット");
        isClose = false;
        isOpen = false;
        Debug.Log(isClose);
        Debug.Log(isOpen);
    }
}
