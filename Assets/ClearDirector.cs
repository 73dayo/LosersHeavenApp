using UnityEngine;
using UnityEngine.SceneManagement;//LoadSceneを使うために必要！

public sealed class ClearDirector : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene("GameScene");
            SceneManager.LoadScene("HomeScene");
        }
    }
}
