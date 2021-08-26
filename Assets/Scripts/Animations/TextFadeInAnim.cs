using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFadeInAnim : MonoBehaviour
{
    [SerializeField]
    private LevelIterator iterator;

    [SerializeField]
    private Text text;

    private void Awake()
    {
        iterator.AddStartListener(OnStartEvent);
    }

    private void OnStartEvent()
    {
        FadeAnimation(2f);
    }

    private void FadeAnimation(float duration)
    {
        var fadeSeq = DOTween.Sequence();
        fadeSeq.Append(text.DOFade(0, 0));
        fadeSeq.Append(text.DOFade(1, duration));
    }
}
