using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField]
    private Deck currentDeck;                       // Набор, играющий на данном уровне

    [SerializeField]
    private LevelIterator iterator;

    private CardData needToFind;                    // Карта, которую необходимо найти

    public CardData NeedToFind()
    {
        return needToFind;
    }

    private void Awake()
    {
        iterator.AddLoadListener(OnLevelLoaded);
    }

    private void OnLevelLoaded(int arg)
    {
        needToFind = currentDeck.GetNewCard();      // Получить новую карту на каждом уровне
    }
}
