using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    private UnityEvent<GameObject> cellTappedEvent = new UnityEvent<GameObject>();        // Событие, срабатываемое при нажатии на ячейку

    private Card card;                                                                    // Карта, хранимая в ячейке

    [SerializeField]
    private Image Background;                                                             // Задний фон ячейки

    public void AddListener(UnityAction<GameObject> listener)
    {
        cellTappedEvent.AddListener(listener);
    }

    public void Init(CardData cardData)
    {
        card.Init(cardData);
    }

    private void Awake()
    {
        card = GetComponent<Card>();
        Background.color = Random.ColorHSV();  
    }

    private void OnMouseUpAsButton()
    {
        cellTappedEvent?.Invoke(gameObject);
    }
}
