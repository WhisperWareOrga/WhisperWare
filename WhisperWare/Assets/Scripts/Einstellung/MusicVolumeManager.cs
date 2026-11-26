using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeManager : MonoBehaviour
{
    public Slider MusicSlider;
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            LoadVolume();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = MusicSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", MusicSlider.value);
    }

    public void LoadVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
