using UnityEngine;

public class Shotgun : Weapon
{
    public override void Shoot(Transform pathPoints)
    {
        if (pathPoints != null)
        {
            foreach (Transform point in pathPoints)
            {
                Instantiate(Bullet, point.position, Quaternion.LookRotation(point.forward, point.up));
            }
        }
    }
}