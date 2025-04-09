using UnityEngine;

public class Shotgun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponData;
    [SerializeField] private Transform shotPoint;

    public int pelletCount = 5;
    public float spreadAngle = 45f;

    private float nextShotTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + weaponData.weaponCoolDown;
            Attack();
        }
    }

    public void Attack()
    {
        float angleStep = spreadAngle / (pelletCount - 1);
        float startAngle = -spreadAngle / 2f;

        for (int i = 0; i < pelletCount; i++)
        {
            GameObject bullet = ObjectPooling.Instance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = shotPoint.position;

                float angle = startAngle + (angleStep * i);
                Quaternion rot = shotPoint.rotation * Quaternion.Euler(0, 0, angle);
                bullet.transform.rotation = rot;

                bullet.SetActive(true);

                Projectile proj = bullet.GetComponent<Projectile>();
                if (proj != null)
                {
                    proj.damage = weaponData.weaponDamage;
                    proj.UpdateProjectileRange(weaponData.weaponRange);
                }
            }
        }
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponData;
    }
}
