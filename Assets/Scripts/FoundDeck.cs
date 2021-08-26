using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundDeck : MonoBehaviour
{
    private List<CardData> foundCards = new List<CardData>();

    public void Add(CardData card)               // �������� � ������ ���������
    {
        foundCards.Add(card);
    }

    public bool WasCardFound(CardData card)      // ���������, ���� �� ������� �����
    {
        if (foundCards.Contains(card))
            return true;
        else
            return false;
    } 
    
    public void Forget()                         // �������� ������ ��������� ����
    {
        foundCards = new List<CardData>();       
    }
}
