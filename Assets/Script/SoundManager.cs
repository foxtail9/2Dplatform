using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;  // BGM 재생용 AudioSource
    public AudioSource vfxSource; // VFX 재생용 AudioSource

    [Header("Audio Clips")]
    public AudioClip defaultBGM; // 기본 BGM 클립

    private void Awake()
    {
        // 싱글턴 패턴 구현
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM(defaultBGM);
    }

    public void PlayBGM(AudioClip clip)
    {
        if (clip != null)
        {
            bgmSource.clip = clip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayVFX(AudioClip clip)
    {
        if (clip != null)
        {
            vfxSource.PlayOneShot(clip); // OneShot은 동시에 여러 효과음을 재생 가능
        }
    }

    /// <summary>
    /// BGM 볼륨 조절
    /// </summary>
    /// <param name="volume">볼륨 (0~100)</param>
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp(volume / 100f, 0f, 1f);
    }

    /// <summary>
    /// VFX 볼륨 조절
    /// </summary>
    /// <param name="volume">볼륨 (0~100)</param>
    public void SetVFXVolume(float volume)
    {
        vfxSource.volume = Mathf.Clamp(volume / 100f, 0f, 1f);
    }
}
