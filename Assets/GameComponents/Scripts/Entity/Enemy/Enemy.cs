using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enemy : Entity
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _reward;
    
    private Player _attackedTarget;

    public Player AttackedTarget => _attackedTarget;
    public float Reward => _reward;

    public void Initialize(Player attackedTarget)
    {
        _attackedTarget = attackedTarget;
    }
}