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
        [SerializeField] GameObject _characterObject;
        [SerializeField] GameObject _imagePrefab;


        //�e�L�X�g�t�@�C������A�������Sprite��GameObject��������悤�ɂ��邽�߂̎���
        //Dictionary<string, Sprite> _textToSprite;
        Dictionary<string, GameObject> _textToParentObject;

        //���삵����Prefab���w��ł���悤�ɂ��邽�߂̎���
        Dictionary<string, GameObject> _textToSpriteObject;

        void Awake()
        {
            _textToParentObject = new Dictionary<string, GameObject>(); //�V��������_textToParentObject���쐬
            _textToParentObject.Add("backgroundObject", _backgroundObject); //_textToParentObject�ɃI�u�W�F�N�g��ǉ�
            _textToParentObject.Add("eventObject", _eventObject); //_textToParentObject�ɃI�u�W�F�N�g��ǉ�
            _textToParentObject.Add("characterObject", _characterObject);

            _textToSpriteObject = new Dictionary<string, GameObject>();//�V����������_textToSpriteObject���쐬

        }



        //�摜��z�u����
        public async UniTaskVoid PutImage(string imageName, string parentObjectName)
        {
            var image = await Addressables.LoadAssetAsync<Sprite>(imageName);//�摜��ǂݍ���

            GameObject parentObject = _textToParentObject[parentObjectName]; //�e�I�u�W�F�N�g

            Vector2 position = new Vector2(0, 0); //2D�̃x�N�^�[���쐬
            Quaternion rotation = Quaternion.identity; //��]���쐬�A.identity�͉�]���Ă��Ȃ��Ƃ����Ӗ��H
            Transform parent = parentObject.transform; //�ړ����쐬

            GameObject item = Instantiate(_imagePrefab, position, rotation, parent); //�I�u�W�F�N�g�𐶐�����

            item.GetComponent<Image>().sprite = image; //�Q�[���I�u�W�F�N�g�iitem�j�̃R���|�[�l���g�H��image����������H
            _textToSpriteObject.Add(imageName, item); //�����ɒǉ��A�폜���Ɏg�p
        }
        

        //�摜���폜����
        public void RemoveImage(string imageName)
        {
            Destroy(_textToSpriteObject[imageName]);
        }



    }
}
