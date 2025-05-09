using UnityEngine;

[CreateAssetMenu(menuName ="New Weapon")]
public class WeaponInfo : ScriptableObject
{
    public Sprite weaponSprite;
    public GameObject weaponPrefab;
    public float weaponCoolDown;
    public int lifeSteal;
    public int weaponDamage;
    public int weaponRange;
}
