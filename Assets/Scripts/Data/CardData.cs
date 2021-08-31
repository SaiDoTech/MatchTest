using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/New CardData")]
public class CardData : ScriptableObject
{
    // Value of the card (displayed as a search requirement).
    [SerializeField] private string _title;

    // Picture of a card.
    [SerializeField] private Sprite _sprite;

    public string Title => this._title;
    public Sprite Sprite => this._sprite;
}
