using UnityEngine;

public class Dispenser : MonoBehaviour
{
    // Set that plays at current level.
    [SerializeField] private Deck currentDeck;

    [SerializeField] private LevelIterator iterator;

    // Card to find.
    private CardData needToFind;

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
        // Get a new card at each level.
        needToFind = currentDeck.GetNewCard();
    }
}
