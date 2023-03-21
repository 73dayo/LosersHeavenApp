using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace NovelGame
{
    public class NameTextController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _mainTextObject;

        private void Start()
        {
            //最初の行のテキストを表示、または命令を実行
            string statement = GameManager.Instance.userScriptManager.GetCurrentSentence();
            GameManager.Instance.MainTextController.DisplayText();
        }

        private void Update()
        {
            //クリックされたとき、次の行へ移動
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.Instance.MainTextController.GoToTheNextLine();
                GameManager.Instance.MainTextController.DisplayText();
            }
        }

    }
}
