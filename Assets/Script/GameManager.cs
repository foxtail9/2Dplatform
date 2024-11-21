using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioClip newBGM; 

    private void Awake()
    {
        ChangeBGM(); 
    }

    private void ChangeBGM()
    {
        SoundManager.Instance.PlayBGM(newBGM);
    }
}
