using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    private Player _attackedTarget;

    protected Player AttackedTarget => _attackedTarget;

    public void Initialize(Player attackedTarget)
    {
        _attackedTarget = attackedTarget;
    }

    public void Enter(Player attackedTarget)
    {
        enabled = true;
        Initialize(attackedTarget);

        foreach (Transition transition in _transitions)
        {
            transition.enabled = true;
            transition.Initialize(attackedTarget);
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if (transition.NeedTransit == true)
            {
                return transition.NextState;
            }
        }

        return null;
    }

    public void Exit()
    {
        foreach (Transition transition in _transitions)
        {
            transition.enabled = false;
        }

        enabled = false;
    }
}