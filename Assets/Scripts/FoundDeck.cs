using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDeck : MonoBehaviour
{
    private List<CardData> foundCards = new List<CardData>();

    public void Add(CardData card)               // Добавить в список найленных
    {
        foundCards.Add(card);
    }

    public bool WasCardFound(CardData card)      // Проверить, была ли найдена карта
    {
        if (foundCards.Contains(card))
            return true;
        else
            return false;
    } 
    
    public void Forget()                         // Очистить список найденных карт
    {
        foundCards = new List<CardData>();       
    }
}
