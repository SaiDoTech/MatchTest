using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField]
    private string bundlesPath = "Cards/Bundles";                        // Путь к набору карт (для упрощения процедуры вставки новых наборов)

    [SerializeField]
    private FoundDeck foundDeck;                                         // Список уже найденных карт

    private CardBundleData[] cardBundles;                                // Загруженные наборы
    private CardData[] currentBundle;                                    // Набор на текущем уровне
    private int currentBudleIndx;
    private System.Random random;

    private Dictionary<int, int> usedTimes = new Dictionary<int, int>(); // Количество карт, используемых из набора

    public CardData GetNewCard()                                         // Получить карту для поиска
    {
        SetNewDeck();

        if (currentBundle != null)
        {
            if (usedTimes[currentBudleIndx] == currentBundle.Length)     // Если в выбранной колоде не осталось карт, которые ещё не играли - сбросить список
                foundDeck.Forget();

            var rndInx = random.Next(currentBundle.Length);
            while (foundDeck.WasCardFound(currentBundle[rndInx]))        // Проверка, не выпадала ли она ранее
                rndInx = random.Next(currentBundle.Length);

            var cardToFind = currentBundle[rndInx];
            usedTimes[currentBudleIndx] = usedTimes[currentBudleIndx] + 1;

            foundDeck.Add(cardToFind);
            return cardToFind;
        }
        else
            return null;
    }

    public CardData GetCard(CardData notThisCard)                        // Получить карту для размещения в таблице, отличную от искомой
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
        cardBundles = Resources.LoadAll<CardBundleData>(bundlesPath);    // Достаточно переместить набор в указанную папку

        for (int i = 0; i < cardBundles.Length; i++)
            usedTimes.Add(i, 0);

        random = new System.Random();
    }

    private void SetNewDeck()                                           // Получить новый набор карт
    {
        currentBudleIndx = random.Next(cardBundles.Length);
        currentBundle = cardBundles[currentBudleIndx].CardData;
    }
}
