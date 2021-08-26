using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/New LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private int _indx;             // ������ ��� ������������������ ��������

    [SerializeField]
    private string _title;         // �������� ������
 
    [SerializeField]
    private int _cellsCount;       // ���������� ����� �� ������

    public int Indx => this._indx;
    public string Title => this._title;
    public int CellsCount => this._cellsCount;
}
