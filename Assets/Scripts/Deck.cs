using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // Path to the set of cards (to simplify the procedure for inserting new sets).
    [SerializeField] private string bundlesPath = "Cards/Bundles";

    // List of already found cards.
    [SerializeField] private FoundDeck foundDeck;

    // Loaded bundles.
    private CardBundleData[] cardBundles;
    // Bundle on current level.
    private CardData[] currentBundle;
    private int currentBudleIndx;
    private System.Random random;

    // <BundleIndx, usedCount> (cards that have already been used).
    private Dictionary<int, int> usedTimes = new Dictionary<int, int>();

    // Get a map to search.
    public CardData GetNewCard()
    {
        SetNewDeck();

        if (currentBundle != null)
        {
            // If there are no cards left in the selected deck that have not yet been played, reset the list.
            if (usedTimes[currentBudleIndx] == currentBundle.Length)
            {
                foundDeck.Forget();
                usedTimes = new Dictionary<int, int>();
            }

            var rndInx = random.Next(currentBundle.Length);

            // Checking if it was dropped earlier.
            while (foundDeck.WasCardFound(currentBundle[rndInx]))
                rndInx = random.Next(currentBundle.Length);

            var cardToFind = currentBundle[rndInx];
            usedTimes[currentBudleIndx] = usedTimes[currentBudleIndx] + 1;

            foundDeck.Add(cardToFind);
            return cardToFind;
        }
        else
            return null;
    }

    // Get a card for placement in the table, different from the one you are looking for.
    public CardData GetCard(CardData notThisCard)
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
        // It is enough to move the bundle to the specified folder.
        cardBundles = Resources.LoadAll<CardBundleData>(bundlesPath);

        for (int i = 0; i < cardBundles.Length; i++)
            usedTimes.Add(i, 0);

        random = new System.Random();
    }

    // Get new bundle.
    private void SetNewDeck()
    {
        currentBudleIndx = random.Next(cardBundles.Length);
        currentBundle = cardBundles[currentBudleIndx].CardData;
    }
}
