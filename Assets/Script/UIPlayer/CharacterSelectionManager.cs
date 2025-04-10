using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public static CharacterSelectionManager Instance;

    [HideInInspector]
    public CharacterData currentSelectedCharacter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentCharacter(CharacterData data)
    {
        currentSelectedCharacter = data;
        PlayerPrefs.SetString("SelectedPrefab", data.characterName);
    }
}
