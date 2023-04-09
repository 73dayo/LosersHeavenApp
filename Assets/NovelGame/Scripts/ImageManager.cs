using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;

namespace NovelGame
{
    public class ImageManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _backgroundObject;

        [SerializeField]
        private GameObject _eventObject;

        [SerializeField]
        private GameObject _characterObject;

        [SerializeField]
        private GameObject _imagePrefab;

        //テキストファイルから、文字列でSpriteやGameObjectを扱えるようにするための辞書
        //Dictionary<string, Sprite> _textToSprite;
        private Dictionary<string, GameObject> _textToParentObject;

        //操作したいPrefabを指定できるようにするための辞書
        private Dictionary<string, GameObject> _textToSpriteObject;

        private void Awake()
        {
            _textToParentObject = new Dictionary<string, GameObject>(); //新しい辞書_textToParentObjectを作成
            _textToParentObject.Add("backgroundObject", _backgroundObject); //_textToParentObjectにオブジェクトを追加
            _textToParentObject.Add("eventObject", _eventObject); //_textToParentObjectにオブジェクトを追加
            _textToParentObject.Add("characterObject", _characterObject);

            _textToSpriteObject = new Dictionary<string, GameObject>();//新しい辞書を_textToSpriteObjectを作成
        }

        //画像を配置する
        public async UniTaskVoid PutImage(string imageName, string parentObjectName)
        {
            var image = await Addressables.LoadAssetAsync<Sprite>(imageName);//画像を読み込む

            GameObject parentObject = _textToParentObject[parentObjectName]; //親オブジェクト

            Vector2 position = new Vector2(0, 0); //2Dのベクターを作成
            Quaternion rotation = Quaternion.identity; //回転を作成、.identityは回転していないという意味？
            Transform parent = parentObject.transform; //移動を作成

            GameObject item = Instantiate(_imagePrefab, position, rotation, parent); //オブジェクトを生成する

            item.GetComponent<Image>().sprite = image; //ゲームオブジェクト（item）のコンポーネント？とimageをくっつける？
            _textToSpriteObject.Add(imageName, item); //辞書に追加、削除時に使用
        }

        //画像を削除する
        public void RemoveImage(string imageName)
        {
            Destroy(_textToSpriteObject[imageName]);
        }
    }
}
