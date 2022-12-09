using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speedModifier;
    [SerializeField] private float _damageForce;

    private void Start()
    {
        InitializeStart();
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessTriggerEnter(collision);
    }

    private void InitializeStart()
    {
        DestroyObjectDelayed();
    }

    private void Move()
    {
        transform.Translate(Vector2.left.normalized * Time.deltaTime * _speedModifier);
    }

    private void DestroyObjectDelayed()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void ProcessTriggerEnter(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damageForce);
            Destroy(gameObject);
        }
    }
}