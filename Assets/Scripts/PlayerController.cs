using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [Header("移動速度 (units / 秒)")]
    [SerializeField] private float speed = 6f;

    [Header("画面端との余白 (units)")]
    [SerializeField] private Vector2 padding = new Vector2(0.5f, 0.5f);

    private Camera _cam;
    private float _halfWidth;
    private float _halfHeight;

    private Vector2 _input;

    void Awake()
    {
        _cam = Camera.main;
        _halfHeight = _cam.orthographicSize;          // 縦方向半径
        _halfWidth  = _halfHeight * _cam.aspect;      // 横方向半径
    }
    // ────────────────────────────────────

    void Update()
    {
        // 入力
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");
        _input = _input.normalized;

        // 移動
        transform.Translate(_input * speed * Time.deltaTime, Space.World);

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(
            pos.x,
            -_halfWidth  + padding.x,
             _halfWidth  - padding.x);

        pos.y = Mathf.Clamp(
            pos.y,
            -_halfHeight + padding.y,
             _halfHeight - padding.y);

        transform.position = pos;
    }
}
