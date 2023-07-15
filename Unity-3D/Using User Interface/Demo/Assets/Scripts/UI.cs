using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public float maxHealth = 30;

    public GameObject mainMenuScreen;

    public GameObject gameScreen;
    public Slider healthSlider;
    public Text scoreText;

    public GameObject gameOverScreen;
    public Text gameOverText;

    private int currentScore;

    private void Awake()
    {
        Time.timeScale = 0;

        mainMenuScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        healthSlider.value = maxHealth;
        healthSlider.maxValue = maxHealth;

        UpdateScore(0);
    }

    private void Update()
    {
        healthSlider.value -= Time.deltaTime;
        
        if (healthSlider.value <= 0)
        {
            ShowGameOver();
        }
    }

    public void OnStartGameClicked()
    {
        Time.timeScale = 1;
        mainMenuScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void UpdateHealth(int value)
    {
        healthSlider.value += value;
    }

    public void UpdateScore(int value)
    {
        currentScore += value;
        this.scoreText.text = $"Score: {currentScore}";
    }

    public void ShowGameOver()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = new Color(154, 0, 0, 255);

    }
}
