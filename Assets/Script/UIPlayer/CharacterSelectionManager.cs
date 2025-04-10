using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public static CharacterSelectionManager Instance;

    [HideInInspector]
    public CharacterData currentSelectedCharacter;

    private void Awake()
    {
        // Đảm bảo chỉ có 1 instance (singleton)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại qua scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentCharacter(CharacterData data)
    {
        currentSelectedCharacter = data;
        PlayerPrefs.SetString("SelectedPrefab", data.characterName); // Lưu prefabName để dùng sau
    }
}
