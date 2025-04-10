using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    public CharacterData characterData;
    public CharacterSelectionUI uiManager;

    public void OnClickSelect()
    {
        uiManager.ShowCharacterData(characterData);
        CharacterSelectionManager.Instance.SetCurrentCharacter(characterData);
    }
}
