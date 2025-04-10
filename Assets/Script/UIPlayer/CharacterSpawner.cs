using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    void Start()
    {
        var characterData = CharacterSelectionManager.Instance.currentSelectedCharacter;

        if (characterData != null)
        {
            string prefabPath = "Player/" + characterData.characterName;
            GameObject prefab = Resources.Load<GameObject>(prefabPath);

            if (prefab != null)
            {
                Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Không tìm thấy prefab tại: " + prefabPath);
            }
        }
        else
        {
            Debug.LogWarning("Không có nhân vật nào được chọn.");
        }
    }
}
