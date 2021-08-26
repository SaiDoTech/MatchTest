using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private string bundlesPath = "Cards/Bundles";                        // ���� � ������ ���� (��� ��������� ��������� ������� ����� �������)

    [SerializeField]
    private FoundDeck foundDeck;                                         // ������ ��� ��������� ����

    private CardBundleData[] cardBundles;                                // ����������� ������
    private CardData[] currentBundle;                                    // ����� �� ������� ������
    private int currentBudleIndx;
    private System.Random random;

    private Dictionary<int, int> usedTimes = new Dictionary<int, int>(); // ���������� ����, ������������ �� ������

    public CardData GetNewCard()                                         // �������� ����� ��� ������
    {
        SetNewDeck();

        if (currentBundle != null)
        {
            if (usedTimes[currentBudleIndx] == currentBundle.Length)     // ���� � ��������� ������ �� �������� ����, ������� ��� �� ������ - �������� ������
                foundDeck.Forget();

            var rndInx = random.Next(currentBundle.Length);
            while (foundDeck.WasCardFound(currentBundle[rndInx]))        // ��������, �� �������� �� ��� �����
                rndInx = random.Next(currentBundle.Length);

            var cardToFind = currentBundle[rndInx];
            usedTimes[currentBudleIndx] = usedTimes[currentBudleIndx] + 1;

            foundDeck.Add(cardToFind);
            return cardToFind;
        }
        else
            return null;
    }

    public CardData GetCard(CardData notThisCard)                        // �������� ����� ��� ���������� � �������, �������� �� �������
    {
        if (currentBundle != null)
        {
            var rndInx = random.Next(currentBundle.Length);

            while (currentBundle[rndInx] == notThisCard)
            {
                rndInx = random.Next(currentBundle.Length);
            }

            return currentBundle[rndInx];
        }
        else
            return null;
    }

    private void Awake()
    {
        cardBundles = Resources.LoadAll<CardBundleData>(bundlesPath);    // ���������� ����������� ����� � ��������� �����

        for (int i = 0; i < cardBundles.Length; i++)
            usedTimes.Add(i, 0);

        random = new System.Random();
    }

    private void SetNewDeck()                                           // �������� ����� ����� ����
    {
        currentBudleIndx = random.Next(cardBundles.Length);
        currentBundle = cardBundles[currentBudleIndx].CardData;
    }
}
