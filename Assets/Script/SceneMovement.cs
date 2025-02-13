using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement : MonoBehaviour
{
    private string SceneName;// シーンの名前

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
