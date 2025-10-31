using UnityEngine;

public class AnimationEventChecker : MonoBehaviour
{
    Enemy enemy;
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void AttackNow()
    {
        enemy.TriggerForAnimation();
    }

}
