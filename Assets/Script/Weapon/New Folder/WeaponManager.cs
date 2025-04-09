using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Transform weaponHolder;                     // Vị trí gắn súng
    public PlayerController playerController;          // Tham chiếu tới PlayerController để cập nhật weapon và shotpoint

    public GameObject currentWeaponGO;                // Lưu prefab hiện tại

    public void EquipNewWeapon(WeaponInfo info)
    {
        // Xoá súng cũ nếu có
        if (currentWeaponGO != null)
        {
            Destroy(currentWeaponGO);
        }

        // Sinh prefab súng mới tại vị trí weaponHolder
        currentWeaponGO = Instantiate(info.weaponPrefab, weaponHolder.position, Quaternion.identity, weaponHolder);

        // Cập nhật tham chiếu weapon và shotpoint cho player
        playerController.weapon = currentWeaponGO.transform;
        playerController.shotpoint = currentWeaponGO.transform.Find("ShotPoint");
        playerController.UpdateWeaponRenderer();

        if (playerController.shotpoint == null)
        {
            Debug.LogWarning("ShotPoint không được tìm thấy trong vũ khí mới!");
        }
    }
}
