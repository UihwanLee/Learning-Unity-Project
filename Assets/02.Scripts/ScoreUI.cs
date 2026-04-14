using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    // UI Fade 담당할 CanvasGroup 컴포넌트
    [SerializeField] private CanvasGroup canvasGroup;

    private Sequence scoreUISeq;

    private void Reset()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        DOTSequence();
    }

    private void DOTSequence()
    {
        // 예외처리
        if (canvasGroup == null) return;

        // 투명화
        canvasGroup.alpha = 0.0f;

        // DOTWeen이 제공하는 Seq 활용
        scoreUISeq = DOTween.Sequence();
        scoreUISeq.Append(transform.DOScale(1.2f, 0.1f))    // 커졌다가
           .Append(transform.DOScale(1.0f, 0.1f))           // 원래대로
           .AppendInterval(0.5f)                            // 잠깐 대기
           .Append(canvasGroup.DOFade(1f, 0.3f))            // 사라짐
           .OnComplete(() => OnCompleteScoreUI());          // 끝나면 함수 호출
    }

    private void OnCompleteScoreUI()
    {
        // Seq가 끝나면 Debug 출력
        Debug.Log("DOTween Seqence가 끝났습니다.");
    }
}
