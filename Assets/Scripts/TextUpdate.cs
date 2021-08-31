using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] private LevelIterator iterator;

    [SerializeField] private Dispenser dispenser;

    [SerializeField] private Text text;

    [SerializeField] private string title = "Find";

    private void Awake()
    {
        iterator.AddLoadListener(OnLevelLoaded);
    }

    private void OnLevelLoaded(int arg)
    {
        text.text = $"{title} {dispenser.NeedToFind().Title}";
    }
}
