using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RectTransform[] buttons;
    public float slideDuration = 0.6f;
    public float delayBetweenButtons = 0.2f;

    public CanvasGroup canvasGroup;
    public float duration;

    public Button playButton;
    public Button settingButton;
    public Button exitButton;

    private void Start()
    {
        SlideInButtons();
        canvasGroup.DOFade(1f, duration);

        playButton.onClick.AddListener(PlayButtonAnimation);
        settingButton.onClick.AddListener(SettingButtonAnimation);
        exitButton.onClick.AddListener(ExitButtonAnimation);
    }

    private void SlideInButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform btn = buttons[i];

            Vector2 targetPos = btn.anchoredPosition;
            btn.anchoredPosition = new Vector2(-500f, targetPos.y);

            btn.DOAnchorPos(targetPos, slideDuration)
                .SetEase(Ease.OutBack)
                .SetDelay(i * delayBetweenButtons);
        }
    }

    public void PlayButtonAnimation()
    {
        playButton.transform.DOScale(1.2f, 0.2f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() => playButton.transform.DOScale(1f, 0.2f));
    }

    public void SettingButtonAnimation()
    {
        settingButton.transform.DORotate(new Vector3(0, 0, 30), 0.2f, RotateMode.Fast)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutBounce);
    }

    public void ExitButtonAnimation()
    {
        exitButton.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 10, 1f);
    }
}
