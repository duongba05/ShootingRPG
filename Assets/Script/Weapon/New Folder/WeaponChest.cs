using UnityEngine;

public class WeaponChest : MonoBehaviour
{
    public WeaponInfo[] weaponList;
    public GameObject droppedWeaponPrefab;
    public GameObject chestOpenVFX;
    public Animator animator;
    private bool isOpened = false;

    public void OpenChest()
    {
        if (isOpened) return;
        isOpened = true;

        animator.SetTrigger("Open");
        Instantiate(chestOpenVFX, transform.position, Quaternion.identity);

        WeaponInfo randomWeapon = weaponList[Random.Range(0, weaponList.Length)];

        GameObject dropped = Instantiate(droppedWeaponPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        dropped.GetComponent<DroppedWeapon>().Setup(randomWeapon);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            OpenChest();
        }
    }
}
