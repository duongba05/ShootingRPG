using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponData;
    [SerializeField] private Transform shotPoint;

    private float nextShotTime;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + weaponData.weaponCoolDown;
            Attack();
        }
    }

    public void Attack()
    {
        GameObject bullet = ObjectPooling.Instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shotPoint.position;
            bullet.transform.rotation = shotPoint.rotation;
            bullet.SetActive(true);

            Projectile proj = bullet.GetComponent<Projectile>();
            if (proj != null)
            {
                proj.damage = weaponData.weaponDamage;
                proj.UpdateProjectileRange(weaponData.weaponRange);
            }
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponData;
    }
}
