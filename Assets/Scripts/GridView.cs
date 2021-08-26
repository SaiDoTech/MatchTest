using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridView : MonoBehaviour
{
    private UnityEvent<Card> cardSelectedEvent = new UnityEvent<Card>();

    [SerializeField]
    private LevelIterator iterator;

    [SerializeField]
    private string startEffect = "PlayCellBounceAnim";                             // Ёффект, который сработает у всех €чеек при загрузке первого уровн€

    public void AddListener(UnityAction<Card> listener)
    {
        cardSelectedEvent.AddListener(listener);
    }

    public void OnGridCellTapped(GameObject cell)
    {
        cardSelectedEvent?.Invoke(cell.GetComponent<Card>());
    }                               // ѕолучить €чейку, которую выбрал пользователь

    private void Start()
    {
        iterator.AddStartListener(OnStartEvent);
        iterator.AddFinishListener(OnFinishEvent);
    }

    private void OnStartEvent()
    {
        var child = gameObject.transform.childCount;

        for (int i=0; i < child; i++)
        {
            gameObject.transform.GetChild(i).SendMessage(startEffect, 1.0f);
        }
    }
    private void OnFinishEvent()
    {
        var child = gameObject.transform.childCount;

        for (int i = 0; i < child; i++)
        {
            gameObject.transform.GetChild(i).gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
