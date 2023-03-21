using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NovelGame
{
    public class GameManager : MonoBehaviour
    {
        //�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂ��邽�߂̂��́i�ύX�͂ł��Ȃ��j
        public static GameManager Instance{get; private set;}

        public UserScriptManager userScriptManager;
        public MainTextController MainTextController;
        public NameTextController NameTextController;
        public ImageManager imageManager;

        //���[�U�[�X�N���v�g�́A���̍s�̐��l�B�N���b�N�i�^�b�v�j�̂��тɂP��������B
        [System.NonSerialized] public int lineNumber;
    
        // Update is called once per frame
        void Awake()
        {
            //�ʂ̃N���X����GameManager�̕ϐ��Ȃǂ��g����悤�ɂȂ�H
            Instance = this;

            lineNumber = 0;
        }
    }
}
