using UnityEngine;
using UnityEngine.SceneManagement;//LoadSceneを使うのに必要

public sealed class PlayerController_kyon : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;

    private float jumpForce = 680.0f;

    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && (this.rigid2D.velocity.y == 0))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //画面外に出た場合は最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene2");
        }

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(-key, 1, 1);
        }

        //プレイヤーの速度に応じてアニメーション速度を変える
        this.animator.speed = speedx / 2.0f;

        //止まっているときに静止画にしたい
        if (this.rigid2D.velocity.x == 0)
        {
            this.animator.SetTrigger("StopTrigger");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }
}
