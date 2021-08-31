using UnityEngine;

public class StarCannon : MonoBehaviour
{
    [SerializeField] private ParticleSystem cannon;

    [SerializeField] private LevelCondition condition;

    private void Start()
    {
        condition.AddListener(OnConditionFulfilled);
    }

    private void OnConditionFulfilled()
    {
        cannon.Play();
    }
}
