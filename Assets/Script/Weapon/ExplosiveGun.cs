using UnityEngine;

public class ExplosiveGun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponData;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private GameObject explosiveBulletPrefab;

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
        GameObject bullet = Instantiate(explosiveBulletPrefab, shotPoint.position, shotPoint.rotation);
        ExplosiveProjectile proj = bullet.GetComponent<ExplosiveProjectile>();
        if (proj != null)
        {
            proj.damage = weaponData.weaponDamage;
            proj.range = weaponData.weaponRange;
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponData;
    }
}
