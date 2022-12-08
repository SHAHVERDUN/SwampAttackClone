using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    private Player _attackedTarget;
    protected bool _needTransit;

    public State NextState => _nextState;
    protected Player AttackedTarget => _attackedTarget;
    public bool NeedTransit => _needTransit;

    private void OnEnable()
    {
        InitializeOnEnable();
    }

    public void InitializeOnEnable()
    {
        _needTransit = false;
    }

    public void Initialize(Player attackedTarget)
    {
        _attackedTarget = attackedTarget;
    }
}