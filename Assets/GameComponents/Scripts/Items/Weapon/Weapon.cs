using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private float _price;
    [SerializeField] private bool _isBuyed;

    public abstract void Shoot(Vector2 shootPoint);
}