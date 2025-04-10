using UnityEngine;
using TMPro;

public class CharacterSelectionUI : MonoBehaviour
{
    public TextMeshProUGUI txtHealth;
    public TextMeshProUGUI txtMana;
    public TextMeshProUGUI txtSpeed;
    public TextMeshProUGUI txtWeapon;
    public TextMeshProUGUI txtCooldown;
    public TextMeshProUGUI txtLifesteal;
    public TextMeshProUGUI txtDamage;
    public TextMeshProUGUI txtRange;
    public void ShowCharacterData(CharacterData data)
    {
        txtHealth.text = "Health: " + data.health;
        txtMana.text = "Mana: " + data.mana;
        txtSpeed.text = "Speed: " + data.speed;
        txtWeapon.text ="Weapon: " +data.weaponName;
        txtCooldown.text = "Cooldown: " + data.cooldown;
        txtLifesteal.text = "Lifesteal: " + data.lifesteal;
        txtDamage.text = "Damage: " + data.damage;
        txtRange.text = "Range: " + data.Range;
    }
}
