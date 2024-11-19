using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public GameObject option;

    public void StartGame()
    {
        // 게임 시작 시, 게임 씬으로 이동
    }

    public void OpenOptions()
    {
        option.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        // 게임 종료
        Application.Quit();
    }
}
