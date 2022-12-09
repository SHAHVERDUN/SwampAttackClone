using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Bullet Bullet;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private float _price;
    [SerializeField] private bool _isBuyed;

    public Sprite Icon => _icon;
    public string Label => _label;
    public float Price => _price;
    public bool IsBuyed => _isBuyed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isBuyed = true;
    }
}