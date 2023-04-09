using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        this.player = GameObject.Find("cat");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
