using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    [SerializeField] private GridView grid;

    [SerializeField] private Dispenser dispenser;

    [SerializeField] private LevelIterator iterator;

    [SerializeField] private float timeBetweenLvl = 1.0f;

    [SerializeField]
    private string positiveEffect = "PlayCardBounceAnim";                   // Ёффект, который выполнитс€ при выполнении услови€ уровн€

    [SerializeField]
    private string negativeEffect = "PlayCardShakeAnim";                    // Ёффект, который выполнитс€, если не пройти проверку

    private UnityEvent ConditionFulfilledEvent = new UnityEvent();

    public void AddListener(UnityAction listener)
    {
        ConditionFulfilledEvent.AddListener(listener);
    }

    // Check level condition.
    public void CheckExecution(Card card)
    {
        // Get the card you are looking for.
        var needToFind = dispenser.NeedToFind().Title;
        if (card.GetTitle() == needToFind)
        {
            card.gameObject.SendMessage(positiveEffect, timeBetweenLvl);
            ConditionFulfilledEvent?.Invoke();

            // Wait for animations to display.
            StartCoroutine(MyWaitForSeconds(timeBetweenLvl));
        }
        else
        {
            card.gameObject.SendMessage(negativeEffect, timeBetweenLvl);
        }
    }

    private void Start()
    {
        grid.AddListener(CheckExecution);
    }

    private IEnumerator MyWaitForSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);

        iterator.LoadNext();
    }
}
