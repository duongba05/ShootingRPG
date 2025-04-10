using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public string gameSceneName = "Game";
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
    public void OnClickPlay()
    {
        if (CharacterSelectionManager.Instance.currentSelectedCharacter != null)
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogWarning("Chưa chọn nhân vật!");
        }
    }
}
