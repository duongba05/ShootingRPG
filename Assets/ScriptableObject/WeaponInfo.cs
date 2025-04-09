using UnityEngine;

[CreateAssetMenu(menuName ="New Weapon")]
public class WeaponInfo : ScriptableObject
{
    public Sprite weaponSprite;
    public GameObject weaponPrefab;
    public float weaponCoolDown;
    public int weaponDamage;
    public float weaponRange;
}
