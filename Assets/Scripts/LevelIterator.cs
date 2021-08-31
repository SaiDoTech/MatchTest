using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class LevelIterator : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;

    private LevelData currentLvl;

    private const int startIndx = -1;
    private int currentIndx;

    // First level loaded.
    private UnityEvent startEvent = new UnityEvent();
    // Next level loaded.
    private UnityEvent<int> levelLoadedEvent = new UnityEvent<int>();
    // Game session is finished.
    private UnityEvent finishEvent = new UnityEvent();
    // Reset game session.
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

    // Load next level.
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

    }

    // Reset current game session.
    public void ResetLevel()
    {
        resetEvent.Invoke();

        currentIndx = startIndx;
        LoadNext();
        startEvent?.Invoke();
    }

    private void Start()
    {
        // Sort for loading.
        levels = levels.OrderBy(lvl => lvl.Indx).ToArray();

        currentIndx = startIndx;
        LoadNext();

        startEvent?.Invoke();
    }
}
