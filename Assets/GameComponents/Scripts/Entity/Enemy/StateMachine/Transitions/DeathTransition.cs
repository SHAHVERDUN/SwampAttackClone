using UnityEngine;

public class DeathTransition : Transition
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if (_enemy.CurrentHealthCount <= 0)
        {
            _needTransit = true;
        }
    }
}