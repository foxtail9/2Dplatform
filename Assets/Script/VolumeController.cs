using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider bgmSlider; 
    public Slider vfxSlider; 

    private void Start()
    {
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        vfxSlider.onValueChanged.AddListener(SetVFXVolume);

        // 초기 슬라이더 값 설정 (0~100)
        bgmSlider.value = SoundManager.Instance.bgmSource.volume * 100f;
        vfxSlider.value = SoundManager.Instance.vfxSource.volume * 100f;
    }

    private void SetBGMVolume(float value)
    {
        SoundManager.Instance.SetBGMVolume(value);
    }

    private void SetVFXVolume(float value)
    {
        SoundManager.Instance.SetVFXVolume(value);
    }
}
