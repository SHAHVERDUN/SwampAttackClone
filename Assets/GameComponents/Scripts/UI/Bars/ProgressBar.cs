using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    protected override void InitializeOnEnable()
    {
        base.InitializeOnEnable();
        _spawner.EnemyCountChanged += SetNewStateBar;
    }

    protected override void InitializeOnDisable()
    {
        base.InitializeOnDisable();
        _spawner.EnemyCountChanged -= SetNewStateBar;
    }

    protected override void InitializeStart()
    {
        base.InitializeStart();
        SetSliderMinValue();
    }
}