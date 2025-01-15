using UnityEngine;

public class WhichStageRelease : MonoBehaviour
{
    public static WhichStageRelease Instance;


    [SerializeField] private int releaseCount = 1;
    public int ReleaseCount => releaseCount;

    void Awake()
    {
        // シングルトンインスタンスの設定
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        releaseCount = PlayerPrefs.GetInt("releaseCount", 0);
        Debug.Log(PlayerPrefs.GetInt("releaseCount", 0));
    }

    public void NewStageRelease()
    {
        if(releaseCount != 3)
        {
           releaseCount++; 
        }
        SaveReleaseCount();
    }
        
    public void SaveReleaseCount()
    {
        PlayerPrefs.SetInt("releaseCount", releaseCount);
        Debug.Log("解放コード：");
        Debug.Log(releaseCount);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        releaseCount = 1;
        PlayerPrefs.SetInt("releaseCount", releaseCount);
        PlayerPrefs.Save();
    }
}
