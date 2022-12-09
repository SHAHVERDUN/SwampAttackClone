using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public abstract class Entity : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;
    public event UnityAction<Entity> Died;

    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _maxHealthCount;

    protected BoxCollider2D BoxCollider2D;
    private float _currentHealthCount;

    public bool IsActive => gameObject.activeSelf;
    public float CurrentHealthCount => _currentHealthCount;

    protected virtual void OnDisable()
    {
        InitializeOnDisable();
    }

    protected virtual void Start()
    {
        InitializeStart();
    }

    protected virtual void Update()
    {
        CheckHealthStatus();
    }

    protected virtual void InitializeOnDisable()
    {
        BoxCollider2D.enabled = true;
    }

    protected virtual void InitializeStart()
    {
        _currentHealthCount = _maxHealthCount;

        BoxCollider2D = GetComponent<BoxCollider2D>();

        HealthChanged?.Invoke(ReturnNormalizedCountOfHealth());
    }

    private void CheckHealthStatus()
    {
        if (_currentHealthCount <= 0)
        {
            _currentHealthCount = 0;

            Die();
        }
        else if (_currentHealthCount > _maxHealthCount)
        {
            _currentHealthCount = _maxHealthCount;
        }
    }

    private float ReturnNormalizedCountOfHealth()
    {
        float normalizedHealthCount = _currentHealthCount / _maxHealthCount;

        return normalizedHealthCount;
    }

    public void TakeDamage(float damageForce)
    {
        _currentHealthCount -= damageForce;

        HealthChanged?.Invoke(ReturnNormalizedCountOfHealth());
    }

    protected virtual void Die()
    {
        Died?.Invoke(this);
    }
}