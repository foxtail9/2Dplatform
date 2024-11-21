using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;  // BGM ����� AudioSource
    public AudioSource vfxSource; // VFX ����� AudioSource

    [Header("Audio Clips")]
    public AudioClip defaultBGM; // �⺻ BGM Ŭ��

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� ����
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
            vfxSource.PlayOneShot(clip); // OneShot�� ���ÿ� ���� ȿ������ ��� ����
        }
    }

    /// <summary>
    /// BGM ���� ����
    /// </summary>
    /// <param name="volume">���� (0~100)</param>
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp(volume / 100f, 0f, 1f);
    }

    /// <summary>
    /// VFX ���� ����
    /// </summary>
    /// <param name="volume">���� (0~100)</param>
    public void SetVFXVolume(float volume)
    {
        vfxSource.volume = Mathf.Clamp(volume / 100f, 0f, 1f);
    }
}
