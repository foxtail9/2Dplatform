using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    public GameObject option;

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenOptions()
    {
        option.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        // ���� ����
        Application.Quit();
    }
}
