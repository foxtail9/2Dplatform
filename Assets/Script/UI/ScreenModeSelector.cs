using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenModeSelector : MonoBehaviour
{
    public Button leftArrowButton;
    public Button rightArrowButton;
    public TextMeshProUGUI screenModeLabel; 

    private int currentModeIndex = 0;
    private readonly string[] screenModes = { "������", "��üȭ��", "�׵θ����� â���" };

    private void Start()
    {
        // �ʱ� ȭ�� ��� ����
        InitializeScreenMode();

        // ��ư Ŭ�� �̺�Ʈ ����
        leftArrowButton.onClick.AddListener(SelectPreviousMode);
        rightArrowButton.onClick.AddListener(SelectNextMode);
    }

    private void InitializeScreenMode()
    {
        // ���� ȭ�� ��带 �ε����� ��������
        FullScreenMode currentMode = Screen.fullScreenMode;
        currentModeIndex = currentMode switch
        {
            FullScreenMode.Windowed => 0,
            FullScreenMode.ExclusiveFullScreen => 1,
            FullScreenMode.FullScreenWindow => 2,
            _ => 2 // �⺻��: Windowed
        };

        UpdateScreenModeLabel();
    }

    private void UpdateScreenModeLabel()
    {
        // TextMeshProUGUI �ؽ�Ʈ ������Ʈ
        screenModeLabel.text = screenModes[currentModeIndex];
    }

    private void ApplyScreenMode()
    {
        // ȭ�� ��� ����
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
        // ���� ��� ����
        currentModeIndex = (currentModeIndex - 1 + screenModes.Length) % screenModes.Length;
        UpdateScreenModeLabel();
        ApplyScreenMode();
    }

    private void SelectNextMode()
    {
        // ���� ��� ����
        currentModeIndex = (currentModeIndex + 1) % screenModes.Length;
        UpdateScreenModeLabel();
        ApplyScreenMode();
    }
}
