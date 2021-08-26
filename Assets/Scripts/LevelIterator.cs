using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class LevelIterator : MonoBehaviour
{
    [SerializeField]
    private LevelData[] levels;

    private LevelData currentLvl;

    private const int startIndx = -1;
    private int currentIndx;

    private UnityEvent startEvent = new UnityEvent();
    private UnityEvent<int> levelLoadedEvent = new UnityEvent<int>();
    private UnityEvent finishEvent = new UnityEvent();
    private UnityEvent resetEvent = new UnityEvent();

    public void AddStartListener(UnityAction listener)
    {
        startEvent.AddListener(listener);
    }

    public void AddLoadListener(UnityAction<int> listener)
    {
        levelLoadedEvent.AddListener(listener);
    }
    public void AddFinishListener(UnityAction listener)
    {
        finishEvent.AddListener(listener);
    }
    public void AddResetListener(UnityAction listener)
    {
        resetEvent.AddListener(listener);
    }

    public void LoadNext()
    {
        currentIndx++;

        if (currentIndx < levels.Length)
        {
            currentLvl = levels[currentIndx];
            levelLoadedEvent.Invoke(currentLvl.CellsCount);
        }
        else
        {
            finishEvent?.Invoke();
        }

    }                                               // Загрузить следующий уровень

    public void ResetLevel()
    {
        resetEvent.Invoke();

        currentIndx = startIndx;
        LoadNext();
        startEvent?.Invoke();
    }                                             // Перезапустить игровой процесс

    private void Start()
    {
        levels = levels.OrderBy(lvl => lvl.Indx).ToArray();                  // Отсортировать для загрузки

        currentIndx = startIndx;
        LoadNext();

        startEvent?.Invoke();
    }
}
