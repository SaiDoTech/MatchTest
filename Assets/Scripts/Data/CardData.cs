using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/New CardData")]
public class CardData : ScriptableObject
{
    [SerializeField]
    private string _title;                  // Значение карты (иуникальное в наборе)

    [SerializeField]
    private Sprite _sprite;                 // Изображение для карты 

    public string Title => this._title;
    public Sprite Sprite => this._sprite;
}
