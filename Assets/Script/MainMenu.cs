using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayBtn;
    public Button OptionBtn;
    public Button ExitBtn;
    public Button CloseBtn;
    public GameObject OptionPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene("SelectionCharacter");
    }
    public void OptionsGame()
    {
        Debug.Log("oPTIONS");
        OptionPanel.SetActive(true);
    }
    public void CloseButton()
    {
        OptionPanel.SetActive(false);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
