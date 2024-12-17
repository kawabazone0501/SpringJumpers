using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    private string SceneName;

    // ゲームオーバー画面のUI
    public GameObject gameOverUI;

    // ゲームクリア画面のUI
    public GameObject gameClearUI;

    // 画面外に出たと判定するY座標の閾値
    public float fallThreshold = -10f;


    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SelectScene()
    {
        SceneName = "SelectScene";
        SceneChoice(SceneName);
    }

    public void FirstScene()
    {
        SceneName = "FirstStageScene";
        SceneChoice(SceneName);
    }

    public void SecondScene()
    {
        SceneName = "SecondStageScene";
        SceneChoice(SceneName);
    }

    public void ThirdScene()
    {
        SceneName = "ThirdStageScene";
        SceneChoice(SceneName);
    }

    private void SceneChoice(string name)
    {
        SceneManager.LoadScene(name);
    }
}
