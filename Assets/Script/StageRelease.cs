using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StageRelease : MonoBehaviour
{
    private int releaseStage = 0;

    [SerializeField] private Button SecondStageButton;
    [SerializeField] private Button ThirdStageButton;

    // Start is called before the first frame update
    void Start()
    {
        releaseStage = PlayerPrefs.GetInt("releaseCount", 0);
        Debug.Log(PlayerPrefs.GetInt("releaseCount", 0));
        ReleaseStage();
    }

    private void ReleaseStage()
    {
        if (releaseStage >= 2)
        {
            SecondStageButton.gameObject.SetActive(true);
        }
        if (releaseStage >= 3)
        {
            ThirdStageButton.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("出現しない");
        }
    }
}
