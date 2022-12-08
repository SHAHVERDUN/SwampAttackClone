using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot(Vector2 shootPoint)
    {
        Instantiate(Bullet, shootPoint, Quaternion.identity);
    }
}