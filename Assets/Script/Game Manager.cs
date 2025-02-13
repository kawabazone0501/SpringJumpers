using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManagerのシングルトンインスタンス
    public static GameManager Instance;

    // ゲームオーバー画面のUI
    [SerializeField] private GameObject gameOverUI;

    // ゲームクリア画面のUI
    [SerializeField] private GameObject gameClearUI;

    //　コントローラーUI
    [SerializeField] private GameObject ControllerUI;

    // 画面外に出たと判定するY座標の閾値
    public float fallThreshold = -10f;

    private bool isCount = false;


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
        Debug.Log(isCount);
        isCount = false;
    }

    // ゲームオーバー時の処理
    public void GameOver()
    {
        // ゲームオーバー画面を表示
        gameOverUI.SetActive(true);
        ControllerUI.SetActive(false);
    }

    // ゲームクリア時の処理
    public void GameClear()
    {
        if (!isCount)
        {
            isCount = true;
            WhichStageRelease.Instance.NewStageRelease();
        }
        // ゲームクリア画面を表示
        gameClearUI.SetActive(true);
        ControllerUI.SetActive(false);
    }

    // リトライボタンが押された時の処理
    public void Retry()
    {
        // 現在のシーンを再読み込み
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 終了ボタンが押された時の処理
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Unityエディターでの動作
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 実際のゲーム終了処理
        Application.Quit();
#endif
    }
}
