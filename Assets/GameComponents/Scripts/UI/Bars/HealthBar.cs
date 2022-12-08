using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Entity _entity;

    protected override void InitializeOnEnable()
    {
        base.InitializeOnEnable();
        _entity.HealthChanged += SetNewStateBar;
    }

    protected override void InitializeOnDisable()
    {
        base.InitializeOnDisable();
        _entity.HealthChanged -= SetNewStateBar;
    }

    protected override void InitializeStart()
    {
        base.InitializeStart();
        SetSliderMaxValue();
    }
}