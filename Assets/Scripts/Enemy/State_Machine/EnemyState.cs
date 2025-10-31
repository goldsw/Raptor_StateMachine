using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMacine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMacine)
    {
        this.enemy = enemy;
        this.enemyStateMacine = enemyStateMacine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FranmeUpdate() { }
    public virtual void PhysicsUpdate() { }
    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType) { }
    public virtual void TriggerForAnimation() { }

}
