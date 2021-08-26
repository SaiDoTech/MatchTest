using UnityEngine;
using DG.Tweening;

public class CardShakeAnim : MonoBehaviour
{
    [SerializeField]
    private RectTransform _transform;

    public void PlayCardShakeAnim(float duration)
    {
        _transform.DOShakePosition(duration, strength: new Vector3(0, 8, 0), vibrato: 10);
    }
}
