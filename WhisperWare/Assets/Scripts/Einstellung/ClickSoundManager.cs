using UnityEngine;
using UnityEngine.UI;

public class ClickSoundManager : MonoBehaviour
{
    public Slider ClickSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("clickVolume"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("clickVolume", 1);
            LoadVolume();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = ClickSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("clickVolume", ClickSlider.value);
    }

    public void LoadVolume()
    {
        ClickSlider.value = PlayerPrefs.GetFloat("clickVolume");
    }
}
