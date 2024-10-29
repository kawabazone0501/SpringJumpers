using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DpadControllerMobile : MonoBehaviour
{
    [SerializeField] private Image uiImage;  // 切り替えるUI画像
    /*
        切り替えで必要な画像リスト
        右方向用の画像
        左方向用の画像
        上方向用の画像
        下方向用の画像
        何も押されていない時の画像
     */
    [SerializeField] private Sprite[] sprites;

    // 右ボタンが押されたとき
    public void OnRightPressed()
    {
        uiImage.sprite = sprites[0]; ;//rightSprite;
    }

    // 左ボタンが押されたとき
    public void OnLeftPressed()
    {
        uiImage.sprite = sprites[1];//leftSprite;
    }

    // 上ボタンが押されたとき
    public void OnUpPressed()
    {
        uiImage.sprite = sprites[2];//upSprite;
    }

    // 下ボタンが押されたとき
    public void OnDownPressed()
    {
        uiImage.sprite = sprites[3];//downSprite;
    }

    // ボタンが離されたとき（画像をリセットする）
    public void OnButtonReleased()
    {
        uiImage.sprite = sprites[4];//neutralSprite;
    }
}
