using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelCondition : MonoBehaviour
{
    [SerializeField]
    private GridView grid;

    [SerializeField]
    private Dispenser dispenser;

    [SerializeField]
    private LevelIterator iterator;

    [SerializeField]
    private float timeBetweenLvl = 1.0f;

    [SerializeField]
    private string positiveEffect = "PlayCardBounceAnim";                   // Эффект, который выполнится при выполнении условия уровня

    [SerializeField]
    private string negativeEffect = "PlayCardShakeAnim";                    // Эффект, который выполнится, если не пройти проверку

    private UnityEvent ConditionFulfilledEvent = new UnityEvent();

    public void AddListener(UnityAction listener)
    {
        ConditionFulfilledEvent.AddListener(listener);
    }

    public void CheckExecution(Card card)                                   // Проверка условия уровня 
    {
        var needToFind = dispenser.NeedToFind().Title;                      // Получить искомую карту
        if (card.GetTitle() == needToFind)
        {
            card.gameObject.SendMessage(positiveEffect, timeBetweenLvl);
            ConditionFulfilledEvent?.Invoke();

            StartCoroutine(MyWaitForSeconds(timeBetweenLvl));               // Подождать для отображения анимаций
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
