using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CelebrationState : State
{
    private Animator _animator;

    private const string CelebrationAnimationMinotaur = nameof(CelebrationAnimationMinotaur);

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

    private void InitializeAwake()
    {
        _animator = GetComponent<Animator>();
    }

    private void InitializeOnEnable()
    {
        _animator.Play(CelebrationAnimationMinotaur);
    }

    private void InitializeOnDisable()
    {
        _animator.StopPlayback();
    }
}