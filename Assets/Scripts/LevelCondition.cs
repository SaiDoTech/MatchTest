using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    [SerializeField] private GridView grid;

    [SerializeField] private Dispenser dispenser;

    [SerializeField] private LevelIterator iterator;

    [SerializeField] private float timeBetweenLvl = 1.0f;

    // Effect that occurs when a level condition is met.
    [SerializeField] private string positiveEffect = "PlayCardBounceAnim";

    // Effect that will occur if the check fails.
    [SerializeField] private string negativeEffect = "PlayCardShakeAnim";

    private UnityEvent ConditionFulfilledEvent = new UnityEvent();

    public void AddListener(UnityAction listener)
    {
        ConditionFulfilledEvent.AddListener(listener);
    }

    // Check level condition.
    public void CheckExecution(Card card)
    {
        // Get the card you are looking for.
        var needToFind = dispenser.NeedToFind();

        if (card.GetData().Equals(needToFind))
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
