using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class TreeAnimationController : MonoBehaviour
{
    [SerializeField] private float _animationSpeedModifier;
    [SerializeField] private float _modifierSpread;
    [SerializeField] private float _timeToChangeAnimation;

    private float _speedModifier;
    private Animator _animator;
    private Coroutine _coroutineSetNewSpeedModifier;

    private const string Speed = nameof(Speed);

    private void Start()
    {
        InitializeStart();
    }

    private void InitializeStart()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat(Speed, _animationSpeedModifier);

        RestartCoroutineSetNewSpeedModifier();
    }

    private void RestartCoroutineSetNewSpeedModifier()
    {
        if (_coroutineSetNewSpeedModifier != null)
        {
            StopCoroutine(_coroutineSetNewSpeedModifier);
        }

        _coroutineSetNewSpeedModifier = StartCoroutine(SetNewSpeedModifier());
    }

    private IEnumerator SetNewSpeedModifier()
    {
        WaitForSeconds timeDelay = new WaitForSeconds(_timeToChangeAnimation);

        while (enabled)
        {
            _speedModifier = _animationSpeedModifier + Random.Range(-1f * _modifierSpread, _modifierSpread);

            yield return timeDelay;

            _animator.SetFloat(Speed, _speedModifier);
        }
    }
}