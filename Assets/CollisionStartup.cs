using UnityEngine;
using UnityEngine.UI;

public sealed class CollisionStartup : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }
}
