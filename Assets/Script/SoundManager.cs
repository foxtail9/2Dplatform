using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public AudioSource bgmAudioSource;  // BGM을 재생할 AudioSource
    public float bgmVolume = 0.75f;  // 기본 BGM 볼륨 (0-1 범위)

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = bgmVolume;
            bgmAudioSource.loop = true;
        }
    }

    public void PlayBGM(AudioClip newBGM)
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.clip = newBGM;  
            bgmAudioSource.Play(); 
        }
    }

    // BGM 볼륨을 변경하는 메서드
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume); 
        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = bgmVolume; 
        }
    }
}
