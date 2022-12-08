using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;
    private Player _attackedTarget;

    private void Start()
    {
        InitializeStart();
    }

    private void Update()
    {
        CheckCurrentState();
    }

    private void InitializeStart()
    {
        _attackedTarget = GetComponent<Enemy>().AttackedTarget;
        ResetState();
    }

    private void ResetState()
    {
        _currentState = _startState;

        if (_currentState != null)
        {
            _currentState.Enter(_attackedTarget);
        }
    }

    private void CheckCurrentState()
    {
        if (_currentState == null)
        {
            return;
        }

        State nextState = _currentState.GetNextState();

        if (nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;
        _currentState.Enter(_attackedTarget);
    }
}