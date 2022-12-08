using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : Entity
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<TextMeshProUGUI> _texts;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;
    private float _money;

    public float Money => _money;

    private const string ShootingGunAnimationPlayer = nameof(ShootingGunAnimationPlayer);
    private const string BaseLayer = nameof(BaseLayer);

    protected override void Update()
    {
        base.Update();

        CheckMouseButton();

        foreach (TextMeshProUGUI text in _texts)
        {
            text.text = _money.ToString();
        }
    }

    protected override void InitializeStart()
    {
        base.InitializeStart();
        _animator = GetComponent<Animator>();
        _currentWeapon = _weapons[0];
    }

    private void CheckMouseButton()
    {
        if (Input.GetMouseButtonDown((int)MouseClick.Left))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_animator.GetCurrentAnimatorStateInfo(_animator.GetLayerIndex(BaseLayer)).IsName(ShootingGunAnimationPlayer) == false)
        {
            _animator.Play(ShootingGunAnimationPlayer);
            _currentWeapon.Shoot(_shootPoint.position);
        }
    }

    public void AddMoney(float reward)
    {
        _money += reward;
    }

    private enum MouseClick : int
    {
        Left,
        Right
    }

    protected override void Die()
    {
        base.Die();

        gameObject.SetActive(false);
    }
}