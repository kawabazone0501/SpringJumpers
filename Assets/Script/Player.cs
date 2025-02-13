using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    //てすと

    [SerializeField] private Transform groundCheck; // 足元のチェックポイント
    [SerializeField] private float checkDistance = 0.2f; // 接地判定の距離

    Animator animator;

    [SerializeField] private Rigidbody2D rbody2D;

    private float jumpForce = 350f;

    private int jumpCount = 0;


    private bool facingRight = true;

    // 画面外に出たかどうかを判定するためのY座標の閾値
    [SerializeField] private float fallThreshold = -10f;

    // ゲームクリアを判定するためのトリガーオブジェクト
    [SerializeField] private GameObject clearTrigger;

    private bool moveRight = false;
    private bool moveLeft = false;
    private bool isGrounded = true;  // 地面にいるかどうかのフラグ

    // 速度関連の変数
    [SerializeField] private float moveSpeed = 5f;       // 通常の移動速度
    private float maxSpeed = 8f;                         // 最大速度
    private float acceleration = 2f;                     // 加速度（増加の割合）
    private float maxAcceleration = 5f;                  // 加速度の上限
    private float deceleration = 5f;                     // 減速の強さ

    // 状態管理の変数
    private float currentSpeed = 0f;                     // 現在の速度
    private float holdTime = 0f;                         // ボタンを押している時間

    // Start is called before the first frame update
    void Start()
    {
        rbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        MovePlayer();
       
        // ジャンプボタンが押されたらジャンプを実行
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            JumpPlayer();
        }
        // プレイヤーキャラクターが画面外に出たかどうかをチェック
        if (transform.position.y < fallThreshold)
        {
            // 画面外に出た場合、ゲームオーバー画面を表示
            GameManager.Instance.GameOver();
        }
    }

    void FixedUpdate()
    {
        // 定期的に地面チェック（タグ "Floor" を探す）
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance);
        if (hit.collider != null && hit.collider.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 足元（FootCollider）がTilemap（Floor）に当たった場合のみ地面判定
        if (other.gameObject.CompareTag("Floor") && other.otherCollider.CompareTag("Foot"))
        {
            jumpCount = 0;  // ジャンプ回数をリセット
            isGrounded = true;  // 地面にいるフラグをリセット
            Debug.Log("地面に接触");
            //animator.SetTrigger("LandTrigger");
        }
        // プレイヤーが指定したオブジェクトに触れた場合、ゲームクリア画面を表示
        if (other.gameObject == clearTrigger)
        {
            GameManager.Instance.GameClear();
        }
    }

    // 足元のColliderから離れた場合にジャンプ不可能にする
    private void OnCollisionExit2D(Collision2D other)
    {
        // 足元（FootCollider）がTilemap（Floor）から離れたらジャンプ不可
        if (other.gameObject.CompareTag("Floor") && other.otherCollider.CompareTag("Foot"))
        {
            isGrounded = false;
            Debug.Log("地面から離れた");
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        // 壁に接触している場合
        if (other.gameObject.CompareTag("Floor") && other.otherCollider.CompareTag("Body"))
        {
            // プレイヤーを少し横に移動させる
            Vector2 slideDirection = new Vector2(-transform.localScale.x * 0.1f, 0); // 左右にスライド
            rbody2D.velocity += slideDirection;
        }
    }
    public void OnRightButtonUp()
    {
        moveRight = false;
    }

    public void OnRightButtonDown()
    {
        moveRight = true;
    }

    public void OnLeftButtonUp()
    {
        moveLeft = false;
    }

    public void OnLeftButtonDown()
    {
        moveLeft = true;
    }

    public void OnTopButtonUp()
    {
        animator.SetBool("isUp", false);
    }

    public void OnTopButtonDown()
    {
        animator.SetBool("isUp", true);
    }

    public void OnBottomButtonUp()
    {
        animator.SetBool("isDown", false);
    }

    public void OnBottomButtonDown()
    {
        animator.SetBool("isDown", true);
    }
    public void MovePlayer()
    {

        Vector2 movement = Vector2.zero;

        //右ボタンが押されている間
        if (moveRight)
        {
            holdTime += Time.deltaTime; //ボタンを押している時間を加算

            //加速度を計算(上限を設ける)
            float currentAcceleration = Mathf.Min(acceleration * holdTime, maxAcceleration);

            //現在の速度を計算(加速度を反映し、最大速度を制限)
            currentSpeed = Mathf.Min(moveSpeed + currentAcceleration, maxSpeed);

            movement = new Vector2(1f, 0f); // 右に移動
        }
        // 左ボタンが押されている時
        else if (moveLeft)
        {
            holdTime += Time.deltaTime; // ボタンを押している時間を加算

            // 加速度を計算（上限を適用）
            float currentAcceleration = Mathf.Min(acceleration * holdTime, maxAcceleration);

            // 現在の速度を計算（加速度を反映し、最大速度を制限）
            currentSpeed = Mathf.Min(moveSpeed + currentAcceleration, maxSpeed);

            movement = new Vector2(-1f, 0f); // 左に移動
        }
        else
        {
            //ボタンが押されていない場合
            holdTime = 0f;

            //徐々に減速
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.deltaTime);
        }
        rbody2D.velocity = new Vector2(movement.x * currentSpeed, rbody2D.velocity.y);

        // 画像の反転
        if (movement.x > 0 && !facingRight)
        {
            Debug.Log($"movement.x: {movement.x}");
            Debug.Log("右");
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Debug.Log($"movement.x: {movement.x}");
            Debug.Log("左");
            Flip();
        }
        

    }

    void Flip()
    {
        Debug.Log("反転");
        facingRight = !facingRight;

        // スプライトの反転
        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        // スプライトの回転を反転 (Y軸方向に180度回転)
        transform.rotation = Quaternion.Euler(0f, facingRight ? 0f : 180f, 0f);
    }

    public void JumpPlayer()
    {
        if(jumpCount < 1)
        {
            rbody2D.AddForce(transform.up * jumpForce);
            jumpCount++;
            isGrounded = false;  // 地面から離れた状態にする
            animator.SetTrigger("isJump");
        }
    }
}
