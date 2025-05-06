using UnityEngine;

/// <summary>
/// 自機移動スクリプト（旧 InputManager 利用）
— 最小実装なので後で Input System 移行も可
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("移動速度 (units / 秒)")]
    [SerializeField] private float speed = 6f;

    private Vector2 _input;

    void Update()
    {
        // 矢印キー & WASD に対応
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        // 斜め移動の速さを一定にする
        _input = _input.normalized;

        transform.Translate(_input * speed * Time.deltaTime, Space.World);
    }
}
