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
        // ゲーム終了
        Application.Quit();
    }
}
