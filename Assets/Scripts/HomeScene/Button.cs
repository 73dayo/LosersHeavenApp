using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
    public void OnClick1()
    {
        SceneManager.LoadSceneAsync("GameScene2");
    }
}
