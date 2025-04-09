using UnityEngine;
using UnityEngine.UI;

public class DroppedWeapon : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public SpriteRenderer weaponSpriteRenderer;
    public GameObject pickupPromptUI;

    private bool playerInRange = false;

    public void Setup(WeaponInfo info)
    {
        weaponInfo = info;
        if (weaponSpriteRenderer != null && weaponInfo.weaponSprite != null)
        {
            weaponSpriteRenderer.sprite = weaponInfo.weaponSprite;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<WeaponManager>().EquipNewWeapon(weaponInfo);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            pickupPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            pickupPromptUI.SetActive(false);
        }
    }
}
