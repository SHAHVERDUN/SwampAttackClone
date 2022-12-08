using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distanceToAttackedTarget;
    [SerializeField] private float _distanceSpread;

    private float _distance;

    private void Start()
    {
        InitializeStart();
    }

    private void Update()
    {
        CheckDistanceToAttackedTarget();
    }

    public void InitializeStart()
    {
        _distance = _distanceToAttackedTarget + Random.Range(-1f * _distanceSpread, _distanceSpread);
    }

    private void CheckDistanceToAttackedTarget()
    {
        if (Vector2.Distance(transform.position, AttackedTarget.transform.position) <= _distance)
        {
            _needTransit = true;
        }
    }
}