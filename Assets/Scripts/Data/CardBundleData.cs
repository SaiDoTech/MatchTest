using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "Data/New CardBundleData")]
public class CardBundleData : ScriptableObject
{
    // Cards in the set.
    [SerializeField] private CardData[] _cardData;

    public CardData[] CardData => this._cardData;
}
