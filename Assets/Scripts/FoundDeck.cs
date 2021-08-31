using System.Collections.Generic;
using UnityEngine;

public class FoundDeck : MonoBehaviour
{
    private List<CardData> foundCards = new List<CardData>();

    // Add to the list of found.
    public void Add(CardData card)
    {
        foundCards.Add(card);
    }

    // Check if the card was found.
    public bool WasCardFound(CardData card)
    {
        if (foundCards.Contains(card))
            return true;
        else
            return false;
    }

    // Clear the list of found cards.
    public void Forget()
    {
        foundCards = new List<CardData>();       
    }
}
