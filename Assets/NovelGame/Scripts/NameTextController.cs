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
            //�ŏ��̍s�̃e�L�X�g��\���A�܂��͖��߂����s
            string statement = GameManager.Instance.userScriptManager.GetCurrentSentence();
            GameManager.Instance.MainTextController.DisplayText();
        }

        private void Update()
        {
            //�N���b�N���ꂽ�Ƃ��A���̍s�ֈړ�
            if (Input.GetMouseButtonUp(0))
            {
                GameManager.Instance.MainTextController.GoToTheNextLine();
                GameManager.Instance.MainTextController.DisplayText();
            }
        }

    }
}
