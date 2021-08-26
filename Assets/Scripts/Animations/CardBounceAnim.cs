using UnityEngine;
using DG.Tweening;

public class CardBounceAnim : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;

    public void PlayCardBounceAnim(float duration)
    {
        var bounceSeq = DOTween.Sequence();
        bounceSeq.Append(_transform.DOScale(Vector3.zero, 0));
        bounceSeq.Append(_transform.DOScale(new Vector3(0.7f, 0.7f, 1), duration / 3));
        bounceSeq.Append(_transform.DOScale(new Vector3(0.55f, 0.55f, 1), duration / 3));
        bounceSeq.Append(_transform.DOScale(new Vector3(0.6f, 0.6f, 1), duration / 3));
    }
}
