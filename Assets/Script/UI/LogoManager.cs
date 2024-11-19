using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    public GameObject companyLogo;
    public GameObject teamLogo;
    public float fadeDuration = 1f; 
    public float displayTime = 2f;  

    private CanvasGroup companyCanvasGroup;
    private CanvasGroup teamCanvasGroup;

    private void Start()
    {
        companyCanvasGroup = companyLogo.GetComponent<CanvasGroup>();
        teamCanvasGroup = teamLogo.GetComponent<CanvasGroup>();
        StartCoroutine(ShowLogos());
    }

    private IEnumerator ShowLogos()
    {
        // 회사 로고 페이드 인y
        yield return StartCoroutine(FadeIn(companyCanvasGroup));
        yield return new WaitForSeconds(displayTime);
        yield return StartCoroutine(FadeOut(companyCanvasGroup));

        // 팀 로고 페이드 인
        yield return StartCoroutine(FadeIn(teamCanvasGroup));
        yield return new WaitForSeconds(displayTime);
        yield return StartCoroutine(FadeOut(teamCanvasGroup));

        SceneManager.LoadScene("MainTile");
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    private IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, timer / fadeDuration); 
            yield return null;
        }
        canvasGroup.alpha = 0;
    }
}
