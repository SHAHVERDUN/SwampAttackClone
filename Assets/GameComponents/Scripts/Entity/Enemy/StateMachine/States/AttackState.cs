using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class AttackState : State
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _damageForce;
    [SerializeField] private float _timeDelayAttack;

    private Animator _animator;
    private Coroutine _coroutineAttack;

    private const string AttackAnimationMinotaur = nameof(AttackAnimationMinotaur);

    private void Start()
    {
        InitializeStart();
    }

    private void Update()
    {
        if (_enemy.CurrentHealthCount <= 0)
        {
            StopCoroutine(_coroutineAttack);
        }
    }

    private void InitializeStart()
    {
        _animator = GetComponent<Animator>();

        RestartCoroutineAttack(AttackedTarget);
    }

    private void RestartCoroutineAttack(Player attackedTarget)
    {
        if (_coroutineAttack != null)
        {
            StopCoroutine(_coroutineAttack);
        }

        _coroutineAttack = StartCoroutine(Attack(attackedTarget));
    }

    private IEnumerator Attack(Player attackedTarget)
    {
        while(AttackedTarget.IsActive == true)
        {
            attackedTarget.TakeDamage(_damageForce);

            _animator.Play(AttackAnimationMinotaur);

            WaitForSeconds timeDelay = new WaitForSeconds(_timeDelayAttack);
            
            yield return timeDelay;
        }
    }
}