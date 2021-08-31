using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/New LevelData")]
public class LevelData : ScriptableObject
{
    // Index for boot sequence.
    [SerializeField] private int _indx;

    // Level name.
    [SerializeField] private string _title;

    // Number of cells per level.
    [SerializeField] private int _cellsCount;

    public int Indx => this._indx;
    public string Title => this._title;
    public int CellsCount => this._cellsCount;
}
