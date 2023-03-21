using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace NovelGame
{
    public class NameTextController : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI _nameTextObject;

        private void Start()
        {
        }

        private void Update()
        {
        }

        public void DisplayName(string a)
        {
            _nameTextObject.text = a;
        }

    }
}
