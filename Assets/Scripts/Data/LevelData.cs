using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/New LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int _indx;             // Индекс для последовательности загрузки

    [SerializeField]
    private string _title;         // Название уровня
 
    [SerializeField]
    private int _cellsCount;       // Количество ячеек на уровне

    public int Indx => this._indx;
    public string Title => this._title;
    public int CellsCount => this._cellsCount;
}
