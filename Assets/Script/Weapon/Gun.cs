using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotPoint;
    public void Attack()
    {
        GameObject newBullet = ObjectPooling.Instance.GetPooledObject();
        if (newBullet != null)
        {
            newBullet.transform.position = shotPoint.position;
            newBullet.transform.rotation = shotPoint.rotation;
            newBullet.SetActive(true);
            newBullet.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
        }
    }
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
