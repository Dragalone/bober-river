using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderVol : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    public void Start()
    {
        slider.value = AudioListener.volume;
        textMeshProUGUI.SetText(Math.Round(slider.value, 2).ToString());
    }
    public void ChangeVolume()
    {
        AudioListener.volume = slider.value;
        textMeshProUGUI.SetText(Math.Round(slider.value,2).ToString());
    }
}
