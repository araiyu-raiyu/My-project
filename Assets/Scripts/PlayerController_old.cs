using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // プレイヤーの移動速度

    private Vector2 movement;
    private Vector2 screenBounds;  // 画面の端を保持するための変数
    private float playerWidth;     // プレイヤーの幅
    private float playerHeight;    // プレイヤーの高さ

    void Start()
    {
        // カメラの表示領域を取得
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        // プレイヤーのサイズを取得
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        playerWidth = playerSprite.bounds.extents.x;  // プレイヤーの幅の半分
        playerHeight = playerSprite.bounds.extents.y; // プレイヤーの高さの半分
    }

    void Update()
    {
        // プレイヤーの入力を受け取る
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // プレイヤーの動きを計算
        movement = new Vector2(moveX, moveY).normalized;  // 入力方向を正規化（斜め移動を調整）
    }

    void LateUpdate()
    {
        // プレイヤーを動かす
        transform.position += (Vector3)(movement * moveSpeed * Time.deltaTime);

        // プレイヤーの位置を画面内に制限
        Vector3 clampedPosition = transform.position;

        // X座標を画面内に制限
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);

        // Y座標を画面内に制限
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);

        // 位置を制限後の座標に適用
        transform.position = clampedPosition;
    }
}
