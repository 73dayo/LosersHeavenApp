using UnityEngine;

namespace NovelGame
{
    public sealed class GameManager : MonoBehaviour
    {
        //別のクラスからGameManagerの変数などを使えるようにするためのもの（変更はできない）
        public static GameManager Instance { get; private set; }

        public UserScriptManager userScriptManager;
        public MainTextController MainTextController;
        public NameTextController NameTextController;
        public ImageManager imageManager;

        //ユーザースクリプトの、今の行の数値。クリック（タップ）のたびに１ずつ増える。
        [System.NonSerialized]
        public int lineNumber;

        private void Awake()
        {
            //別のクラスからGameManagerの変数などを使えるようになる？
            Instance = this;

            lineNumber = 0;
        }
    }
}
