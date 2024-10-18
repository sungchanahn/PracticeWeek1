using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDashboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;
    [SerializeField] private TextMeshProUGUI currentHeight;
    [SerializeField] private GameObject rocket;
    private int highScore = 0;
    private int currentScore = 0;
    private string key = "HighScore";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(key))
        {
            highScore = PlayerPrefs.GetInt(key);
        }
    }

    private void Update()
    {
        currentHeight.text = $"{(int)rocket.transform.position.y} M";

        if ((int)rocket.transform.position.y > currentScore)
        {
            currentScore = (int)rocket.transform.position.y;
        }
        currentScoreTxt.text = $"Now Score: {currentScore} M";

        if (highScore < currentScore)
        {
            highScore = currentScore;
        }
        highScoreTxt.text = $"Best Score: {highScore} M";
    }

    private void SaveHighScore()
    {
        if (PlayerPrefs.HasKey(key))
        {
            if (PlayerPrefs.GetInt(key) < highScore)
            {
                PlayerPrefs.SetInt(key, highScore);
            }
        }
        else
        {
            PlayerPrefs.SetInt(key, highScore);
        }
    }

    public void ResetBtn()
    {
        SaveHighScore();
        SceneManager.LoadScene("RocketLauncher");
    }
}
