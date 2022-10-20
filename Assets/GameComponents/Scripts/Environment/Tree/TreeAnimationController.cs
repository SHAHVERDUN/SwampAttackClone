using UnityEngine;

[RequireComponent(typeof(Animator))]

public class TreeAnimationController : MonoBehaviour
{
    [SerializeField]
    private float _velocityModifier;

    private Animator _animator;

    private const string Speed = nameof(Speed);

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetFloat(Speed, _velocityModifier);
    }
}