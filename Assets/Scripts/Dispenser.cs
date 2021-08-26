using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispenser : MonoBehaviour
{
    [SerializeField]
    private Deck currentDeck;                       // �����, �������� �� ������ ������

    [SerializeField]
    private LevelIterator iterator;

    private CardData needToFind;                    // �����, ������� ���������� �����

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
        needToFind = currentDeck.GetNewCard();      // �������� ����� ����� �� ������ ������
    }
}
