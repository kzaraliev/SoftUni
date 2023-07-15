using UnityEngine;
using UnityEngine.UI;

public class Canva : MonoBehaviour
{
    public Slider timerSlider;
    private float gameTime = 60f;
    private float bonusTime = 5f;

    public Text counter;
    private int counterPoints = 0;
    private int maxPoints = 4;

    public Image gameOverScreen;
    public Text gameOverText;


    // Start is called before the first frame update
    public void Start()
    {
        gameOverScreen.gameObject.SetActive(false);

        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;

        counter.text = $"{counterPoints} / {maxPoints}";

        gameOverScreen.enabled = false;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timerSlider.value -= Time.deltaTime;

        if (timerSlider.value <= 0)
        {
            GameOver();
        }
    }

    public void UpdateTimer()
    {
        timerSlider.value += bonusTime;
    }

    public void UpdateCounter()
    {
        counterPoints++;
        counter.text = $"{counterPoints} / {maxPoints}";

        if (counterPoints == maxPoints)
        {
            gameOverScreen.enabled = true;
            gameOverText.enabled = true;
            gameOverText.text = "Passed";
            gameOverText.color = Color.green;
        }
    }

    public void GameOver()
    {
        gameOverScreen.enabled = true;
        gameOverText.enabled = true;
        gameOverText.text = "YOU DIED";
        gameOverText.color = Color.red;
    }
}
