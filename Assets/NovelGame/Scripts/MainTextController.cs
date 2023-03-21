using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace NovelGame
{
    public class MainTextController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _mainTextObject;

        //文字を１文字ずつ表示するためのやつ
        int _displayedSentenceLength;
        int _sentenceLength;
        float _time;
        float _feedTime;

        // Start is called before the first frame update
        void Start()
        {
            _time = 0f;
            _feedTime = 0.05f;


            //最初の行のテキストを表示、または命令を実行
            string statement = GameManager.Instance.userScriptManager.GetCurrentSentence();
            if(GameManager.Instance.userScriptManager.IsStatement(statement)) //取得した文字が"&"のとき
            {
                GameManager.Instance.userScriptManager.ExecuteStatement(statement); //画像を配置する
                GoToTheNextLine();
            }

            DisplayText();
        }

        // Update is called once per frame
        void Update()
        {

            //文章を１文字ずつ表示する
            _time += Time.deltaTime;
            if(_time>=_feedTime)
            {
                _time -= _feedTime;

                if(!CanGoToTheNextLine())
                {
                    _displayedSentenceLength++;
                    _mainTextObject.maxVisibleCharacters = _displayedSentenceLength;
                }
            }


            //クリックされたとき、次の行へ移動
            if(Input.GetMouseButtonUp(0))
            {
                if (CanGoToTheNextLine())
                {
                    GoToTheNextLine();
                    DisplayText();
                }
                else
                {
                    _displayedSentenceLength = _sentenceLength;
                }
            }
        }


        //その行の、すべての文字が表示されていなければ、まだ次の行へ進むことはできない
        public bool CanGoToTheNextLine()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            return (_displayedSentenceLength > sentence.Length);
        }


        //シナリオ、次の行へ移動
        public void GoToTheNextLine()
        {

            _displayedSentenceLength = 0;
            _time = 0f;
            _mainTextObject.maxVisibleCharacters = 0;

            GameManager.Instance.lineNumber++;
            string statement = GameManager.Instance.userScriptManager.GetCurrentSentence();
            if(GameManager.Instance.userScriptManager.IsStatement(statement))
            {
                GameManager.Instance.userScriptManager.ExecuteStatement(statement);
                GoToTheNextLine();
            }
        }

        public void DisplayText()
        {
            string sentence = GameManager.Instance.userScriptManager.GetCurrentSentence();
            _mainTextObject.text = sentence;
        }
         

    }
}
