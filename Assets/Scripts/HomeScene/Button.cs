﻿using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class Button : MonoBehaviour
{
    // ボタンが押された場合、今回呼び出される関数
    public void OnClick1()
    {
        SceneManager.LoadSceneAsync("GameSelectScene");
    }
}
