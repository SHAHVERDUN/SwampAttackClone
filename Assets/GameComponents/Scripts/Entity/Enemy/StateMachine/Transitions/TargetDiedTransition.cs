using UnityEngine;

public class TargetDiedTransition : Transition
{
    private void Update()
    {
        CheckDeathOfAttackedTarget();
    }

    private void CheckDeathOfAttackedTarget()
    {
        if (AttackedTarget.IsActive == false)
        {
            _needTransit = true;
        }
    }
}