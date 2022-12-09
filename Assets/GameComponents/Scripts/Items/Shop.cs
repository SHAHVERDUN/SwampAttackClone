using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        WeaponView view = Instantiate(_template, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(weapon);
    }

    private void OnBuyButtonClick(Weapon weapon, WeaponView view)
    {
        TryBuyWeapon(weapon, view);
    }

    private void TryBuyWeapon(Weapon weapon, WeaponView view)
    {
        if (weapon.Price <= _player.Money)
        {
            _player.BuyWeapon(weapon);
            weapon.Buy();
            view.BuyButtonClick -= OnBuyButtonClick;
        }
    }
}