using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speed_Bar : MonoBehaviour
{
    public Slider slider;

    public void SetMinSpeedScore(int speed)
    {
        slider.minValue = speed;
        slider.value = speed;
    }

    public void SetSpeedScore(int speed)
    {
        slider.value = speed;
    }
}
