using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayBtn;
    public Button OptionBtn;
    public Button ExitBtn;
    void Start()
    {
        PlayBtn.onClick.AddListener(PlayGame);
        ExitBtn.onClick.AddListener(ExitGame);
    }
    void PlayGame()
    {
        SceneManager.LoadScene("SelectionCharacter");
    }
    void OptionsGame()
    {
        Debug.Log("oPTIONS");
    }
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
