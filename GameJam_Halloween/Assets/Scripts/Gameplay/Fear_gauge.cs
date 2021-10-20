using UnityEngine;
using UnityEngine.UI;

public class Fear_gauge : MonoBehaviour
{
    public Slider slider;

    public void SetMinFear(int fear)
    {
        slider.minValue = fear;
        slider.value = fear;
    }

    public void SetFear(int fear)
    {
        slider.value = fear;
    }
}
