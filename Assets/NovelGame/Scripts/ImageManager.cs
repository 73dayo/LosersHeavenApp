using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace NovelGame
{

    public class ImageManager : MonoBehaviour
    {
        [SerializeField] GameObject _backgroundObject;
        [SerializeField] GameObject _eventObject;
        [SerializeField] GameObject _imagePrefab;


        //テキストファイルから、文字列でSpriteやGameObjectを扱えるようにするための辞書
        //Dictionary<string, Sprite> _textToSprite;
        Dictionary<string, GameObject> _textToParentObject;

        //操作したいPrefabを指定できるようにするための辞書
        Dictionary<string, GameObject> _textToSpriteObject;

        void Awake()
        {
            _textToParentObject = new Dictionary<string, GameObject>(); //新しい辞書_textToParentObjectを作成
            _textToParentObject.Add("backgroundObject", _backgroundObject); //_textToParentObjectにオブジェクトを追加
            _textToParentObject.Add("eventObject", _eventObject); //_textToParentObjectにオブジェクトを追加
            _textToSpriteObject = new Dictionary<string, GameObject>();//新しい辞書を_textToSpriteObjectを作成

        }



        //画像を配置する
        public async UniTaskVoid PutImage(string imageName, string parentObjectName)
        {
            var image = await Addressables.LoadAssetAsync<Sprite>(imageName);
            //Sprite image =_textToSprite[imageName];//入力された画像を取り出す
            GameObject parentObject = _textToParentObject[parentObjectName];

            Vector2 position = new Vector2(0, 0);
            Quaternion rotation = Quaternion.identity;
            Transform parent = parentObject.transform;
            GameObject item = Instantiate(_imagePrefab, position, rotation, parent);
            item.GetComponent<Image>().sprite = image;
            _textToSpriteObject.Add(imageName, item);
        }
        

        //画像を削除する
        public void RemoveImage(string imageName)
        {
            Destroy(_textToSpriteObject[imageName]);
        }



    }
}
