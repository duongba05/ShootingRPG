using UnityEngine;

public class LaserGun : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponData;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private LineRenderer laserLine;
    [SerializeField] private float laserDuration = 0.1f;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private EdgeCollider2D edgeCollider;

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
        RaycastHit2D hit = Physics2D.Raycast(shotPoint.position, shotPoint.right, weaponData.weaponRange, enemyLayer);
        Vector3 endPos = shotPoint.position + shotPoint.right * weaponData.weaponRange;

        if (hit.collider != null)
        {
            endPos = hit.point;
            hit.collider.GetComponent<EnemyHealth>()?.TakeDamage(weaponData.weaponDamage);
        }

        StartCoroutine(ShowLaser(endPos));
    }

    private System.Collections.IEnumerator ShowLaser(Vector3 endPos)
    {
        laserLine.SetPosition(0, shotPoint.position);
        laserLine.SetPosition(1, endPos);
        laserLine.enabled = true;
        edgeCollider.enabled = true;

        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
        edgeCollider.enabled=false;
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponData;
    }
}
