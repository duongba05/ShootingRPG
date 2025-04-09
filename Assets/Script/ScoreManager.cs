using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public int kill;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI killText;

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;    
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = " " + score;
    } 
    public void AddKill(int killAmount)
    {
        kill += killAmount;
        killText.text = " " + kill;
    } 
}
