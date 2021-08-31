using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private CardData data;

    [SerializeField] private Image img;

    public void Init(CardData data)
    {
        this.data = data;
        img.sprite = data.Sprite;
    }

    public string GetTitle()
    {
        return data.Title;
    }
}
