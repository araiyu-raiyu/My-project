using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 2f;      // 秒

    private float _timer;

    public void Fire(Vector3 direction)
    {
        _timer = 0f;
        gameObject.SetActive(true);
        this.direction = direction;
    }

    private Vector3 direction = Vector3.up;

    void OnEnable() => _timer = 0f;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        _timer += Time.deltaTime;
        if (_timer >= lifeTime)
        {
            gameObject.SetActive(false);   // プールへ戻る
        }
    }
}
