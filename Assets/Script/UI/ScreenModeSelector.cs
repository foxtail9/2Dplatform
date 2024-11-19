using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenModeSelector : MonoBehaviour
{
    public Button leftArrowButton;
    public Button rightArrowButton;
    public TextMeshProUGUI screenModeLabel; 

    private int currentModeIndex = 0;
    private readonly string[] screenModes = { "윈도우", "전체화면", "테두리없는 창모드" };

    private void Start()
    {
        // 초기 화면 모드 설정
        InitializeScreenMode();

        // 버튼 클릭 이벤트 연결
        leftArrowButton.onClick.AddListener(SelectPreviousMode);
        rightArrowButton.onClick.AddListener(SelectNextMode);
    }

    private void InitializeScreenMode()
    {
        // 현재 화면 모드를 인덱스로 가져오기
        FullScreenMode currentMode = Screen.fullScreenMode;
        currentModeIndex = currentMode switch
        {
            FullScreenMode.Windowed => 0,
            FullScreenMode.ExclusiveFullScreen => 1,
            FullScreenMode.FullScreenWindow => 2,
            _ => 2 // 기본값: Windowed
        };

        UpdateScreenModeLabel();
    }

    private void UpdateScreenModeLabel()
    {
        // TextMeshProUGUI 텍스트 업데이트
        screenModeLabel.text = screenModes[currentModeIndex];
    }

    private void ApplyScreenMode()
    {
        // 화면 모드 변경
        switch (currentModeIndex)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
        }
    }

    private void SelectPreviousMode()
    {
        // 이전 모드 선택
        currentModeIndex = (currentModeIndex - 1 + screenModes.Length) % screenModes.Length;
        UpdateScreenModeLabel();
        ApplyScreenMode();
    }

    private void SelectNextMode()
    {
        // 다음 모드 선택
        currentModeIndex = (currentModeIndex + 1) % screenModes.Length;
        UpdateScreenModeLabel();
        ApplyScreenMode();
    }
}
