using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider bgmSlider;

    private void Start()
    {
        bgmSlider.value = SoundManager.Instance.bgmVolume * 100f; 
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
    }

    private void OnBGMVolumeChanged(float value)
    {
        SoundManager.Instance.SetBGMVolume(value / 100f); 
    }
}
