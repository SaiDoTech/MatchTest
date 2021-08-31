using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private LevelIterator iterator;

    private void Start()
    {
        gameObject.SetActive(false);
        iterator.AddFinishListener(OnFinishEvent);
        iterator.AddResetListener(OnResetEvent);
    }

    private void OnFinishEvent()
    {
        gameObject.SetActive(true);
    }
    private void OnResetEvent()
    {
        gameObject.SetActive(false);
    }
}
