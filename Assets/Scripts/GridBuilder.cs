using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [SerializeField] private GameObject gridCell;
 
    [SerializeField] private GridView grid;

    [SerializeField] private LevelIterator iterator;

    [SerializeField] private Dispenser dispenser;

    [SerializeField] private Deck deck;

    private System.Random rnd;

    private void Awake()
    {
        rnd = new System.Random();
    }

    private void Start()
    {
        iterator.AddLoadListener(OnLevelLoaded);
    }

    private void OnLevelLoaded(int cellsCount)
    {
        BuildGrid(cellsCount, deck);
    }

    private void BuildGrid(int cellsCount, Deck deck)
    {
        DestoyGrid();

        var needCard = dispenser.NeedToFind();
        // Get the cell number for the required card.
        var rndInx = rnd.Next(0, cellsCount);

        for (int i = 0; i < cellsCount; i++)
        {
            var newCell = Instantiate(gridCell, transform);
            newCell.GetComponent<CellView>().AddListener(grid.OnGridCellTapped);

            if (i == rndInx)
            {
                // Get the cell number for the required card.
                newCell.GetComponent<CellView>().Init(needCard);
            }
            else
            {
                // Place another card.
                newCell.GetComponent<CellView>().Init(deck.GetCard(needCard));
            }
        }
    }

    private void DestoyGrid()
    {
        var needDestroy = gameObject.transform.childCount;
        for (int i = 0; i < needDestroy; i++)
        {
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
