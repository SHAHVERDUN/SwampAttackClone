using UnityEngine;

[RequireComponent(typeof(Animator))]

public class DeathState : State
{
    [SerializeField] private float _delayBeforeDisappearing;
    [SerializeField] private HealthBar _healthBar;

    private float _timeAfterLastSpawn;
    private Animator _animator;

    private const string DeathAnimationMinotaur = nameof(DeathAnimationMinotaur);

    private void Awake()
    {
        InitializeAwake();
    }

    private void OnEnable()
    {
        InitializeOnEnable();
    }

    private void OnDisable()
    {
        InitializeOnDisable();
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _delayBeforeDisappearing)
        {
            _timeAfterLastSpawn = 0;

            gameObject.SetActive(false);
        }
    }

    private void InitializeAwake()
    {
        _animator = GetComponent<Animator>();
    }

    private void InitializeOnEnable()
    {
        _healthBar.gameObject.SetActive(false);
        _animator.Play(DeathAnimationMinotaur);
    }

    private void InitializeOnDisable()
    {
        _animator.StopPlayback();
    }
}