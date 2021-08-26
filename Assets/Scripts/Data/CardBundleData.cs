using UnityEngine;

[CreateAssetMenu(fileName = "CardBundleData", menuName = "Data/New CardBundleData")]
public class CardBundleData : ScriptableObject
{
    [SerializeField]
    private CardData[] _cardData;                  // Карты в наборе

    public CardData[] CardData => this._cardData;
}
