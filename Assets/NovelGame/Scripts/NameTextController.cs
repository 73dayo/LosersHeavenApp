using UnityEngine;
using TMPro;

namespace NovelGame
{
    public class NameTextController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _nameTextObject;

        public void DisplayName(string a)
        {
            _nameTextObject.text = a;
        }
    }
}
