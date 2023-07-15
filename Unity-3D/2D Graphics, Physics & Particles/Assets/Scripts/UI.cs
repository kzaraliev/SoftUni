using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Slider timerUI;
    public Text gateCouterText;
    public Image gameOverScreen;
    public Text gameOverText;

    public int timerDefaultValue = 10;
    public int gateTimeBonusValue = 5;

    private int gatesPassed = -1;
    private int maxGatesCount;

    public CounterBar counterBarUI;

    public void Start()
    {
        gameOverScreen.gameObject.SetActive(false);
        timerUI.value = timerDefaultValue;
        timerUI.minValue = 0;
        timerUI.maxValue = timerUI.value;
        maxGatesCount = GameObject.Find("Obstacles").transform.childCount;
        UpdateGateCounter();

        counterBarUI.SetPoints();
        counterBarUI.SetMaxPoints(maxGatesCount);
    }

    public void Update()
    {
        timerUI.value -= Time.deltaTime;
        if (timerUI.value <= 0)
        {
            ShowGameOverScreenFail();
        }

        if (gatesPassed >= maxGatesCount)
        {
            ShowGameOverScreenPassed();
        }
    }

    public void UpdateTimer()
    {
        timerUI.value += gateTimeBonusValue;
    }

    public void UpdateGateCounter()
    {
        counterBarUI.UpdatePoints();
        gatesPassed += 1;
        gateCouterText.text = $"{gatesPassed} / {maxGatesCount}";
    }

    public void ShowGameOverScreenPassed()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "Passed";
        gameOverText.color = Color.green;
    }

    public void ShowGameOverScreenDeath()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "YOU DIED";
        gameOverText.color = Color.red;
    }

    public void ShowGameOverScreenFail()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.text = "FAILED";
        gameOverText.color = Color.red;
    }

    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
