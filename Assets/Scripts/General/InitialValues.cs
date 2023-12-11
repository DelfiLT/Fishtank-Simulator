using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitialValues : MonoBehaviour
{
    [Header("Sliders/Toggle")]
    public Slider fishQuantitySlider;
    public Slider fishAgeSlider;
    public Slider timeScaleSlider;
    public Toggle cleaningToggle;

    [Header("Values")]
    public TextMeshProUGUI fishQuantityValue;
    public TextMeshProUGUI fishAgeValue;
    public TextMeshProUGUI timeScaleValue;
    private int cleaningToggleValue;

    private void Start()
    {
        PlayerPrefs.SetInt("FishQuantity", ((int)fishQuantitySlider.value));
        PlayerPrefs.SetInt("FishAge", ((int)fishAgeSlider.value));
        PlayerPrefs.SetInt("TimeScale", ((int)timeScaleSlider.value));
        PlayerPrefs.SetInt("CleaningToggle", cleaningToggleValue);
    }

    void Update()
    {
        fishQuantityValue.text = fishQuantitySlider.value.ToString();
        fishAgeValue.text = fishAgeSlider.value.ToString();
        timeScaleValue.text = timeScaleSlider.value.ToString();
    }

    public void FishQuantitySliderChange()
    {
        PlayerPrefs.SetInt("FishQuantity", ((int)fishQuantitySlider.value));
    }

    public void FishAgeSliderChange()
    {
        PlayerPrefs.SetFloat("FishAge", fishAgeSlider.value);
    }

    public void TimeScaleSliderChange()
    {
        PlayerPrefs.SetFloat("TimeScale", timeScaleSlider.value);
    }

    public void CleaningToggleChange()
    {
        if (cleaningToggle.isOn)
        {
            cleaningToggleValue = 1;
        }
        else
        {
            cleaningToggleValue = 0;
        }

        PlayerPrefs.SetInt("CleaningToggle", cleaningToggleValue);
    }
}
