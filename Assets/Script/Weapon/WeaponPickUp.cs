//using UnityEngine;

//public class WeaponPickup : MonoBehaviour
//{
//    public WeaponInfo weaponInfo; 
//    private bool playerInRange = false;
//    private Transform playerTransform;
//    private PlayerController playerController;

//    [SerializeField] private GameObject swapText;

//    void Start()
//    {
//        if (swapText != null)
//            swapText.SetActive(false); 
//    }

//    void Update()
//    {
//        if (playerInRange && Input.GetKeyDown(KeyCode.E))
//        {
//            SwapWeapon();
//        }
//    }

//    private void SwapWeapon()
//    {
//        if (playerController == null) return;

//        Transform weaponHolder = playerTransform.Find("Weapon/WeaponHold");
//        if (weaponHolder == null) return;

//        if (weaponHolder.childCount > 0)
//        {
//            Transform currentWeapon = weaponHolder.GetChild(0);
//            currentWeapon.SetParent(null);
//            currentWeapon.position = transform.position;

//            WeaponPickup oldPickup = currentWeapon.GetComponent<WeaponPickup>();
//            if (oldPickup == null)
//                oldPickup = currentWeapon.gameObject.AddComponent<WeaponPickup>();

//            oldPickup.weaponInfo = playerController.GetCurrentWeapon().GetWeaponInfo();

//            if (oldPickup.swapText == null && swapText != null)
//            {
//                oldPickup.swapText = swapText;
//            }
//        }

//        GameObject newWeapon = Instantiate(weaponInfo.weaponPrefab, weaponHolder.position, weaponHolder.rotation, weaponHolder);
//        IWeapon newWeaponScript = newWeapon.GetComponent<IWeapon>();
//        playerController.SetWeapon(newWeaponScript);

//        Destroy(gameObject);
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerInRange = true;
//            playerTransform = other.transform;
//            playerController = other.GetComponent<PlayerController>();

//            if (swapText != null)
//                swapText.SetActive(true);
//        }
//    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            playerInRange = false;
//            playerTransform = null;
//            playerController = null;

//            if (swapText != null)
//                swapText.SetActive(false);
//        }
//    }
//}
