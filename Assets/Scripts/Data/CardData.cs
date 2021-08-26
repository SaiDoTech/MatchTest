using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Data/New CardData")]
public class CardData : ScriptableObject
{
    [SerializeField]
    private string _title;                  // �������� ����� (����������� � ������)

    [SerializeField]
    private Sprite _sprite;                 // ����������� ��� ����� 

    public string Title => this._title;
    public Sprite Sprite => this._sprite;
}
