using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    // Event triggered when clicking on a cell.
    private UnityEvent<GameObject> cellTappedEvent = new UnityEvent<GameObject>();

    // Card stored in a cell.
    private Card card;

    // Cell background.
    [SerializeField] private Image Background;

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
