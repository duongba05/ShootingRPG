using UnityEngine;

public class ShotGun : MonoBehaviour
{
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
        }
    }
}
