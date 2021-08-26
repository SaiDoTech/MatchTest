using UnityEngine;
using DG.Tweening;

public class CellBounceAnim : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;

    public void PlayCellBounceAnim(float duration)
    {
        var bounceSeq = DOTween.Sequence();
        bounceSeq.Append(_transform.DOScale(Vector3.zero, 0));
        bounceSeq.Append(_transform.DOScale(new Vector3(1.2f, 1.2f, 1), duration / 3));
        bounceSeq.Append(_transform.DOScale(new Vector3(0.95f, 0.95f, 1), duration / 3));
        bounceSeq.Append(_transform.DOScale(new Vector3(1, 1, 1), duration / 3));
    }
}
