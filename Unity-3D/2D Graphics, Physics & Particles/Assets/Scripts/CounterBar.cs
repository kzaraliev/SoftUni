using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPoints(int points)
    {
        slider.minValue = 0;
        slider.maxValue = points;
    }

    public void SetPoints()
    {
        slider.value = 0;
    }

    public void UpdatePoints()
    {
        slider.value++;
    }
}
