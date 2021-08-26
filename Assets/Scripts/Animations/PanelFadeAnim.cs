using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PanelFadeAnim : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private LevelIterator iterator;

    private void Start()
    {
        iterator.AddFinishListener(OnFinishEvent);
        iterator.AddResetListener(OnResetEvent);
    }

    private void OnFinishEvent()
    {
        HalfFadeAnimation(2);
    }
    private void OnResetEvent()
    {
        FullFadeAnimation(1);
    }

    private void HalfFadeAnimation(float duration)
    {
        var fadeSeq = DOTween.Sequence();
        fadeSeq.Append(image.DOFade(0, 0));
        fadeSeq.Append(image.DOFade(0.5f, duration));
    }

    private void FullFadeAnimation(float duration)
    {
        var fadeSeq = DOTween.Sequence();
        fadeSeq.Append(image.DOFade(1, duration/10));
        fadeSeq.Append(image.DOFade(0, duration - (duration/10)));
    }
}
