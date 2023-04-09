using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class HomeDirector : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {

            SceneManager.LoadScene("GameScene");
        }
    }
}
