using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private float chaseSpeed = 7f;
    private float _aggroedTime = 3f;
    private float timer = 0f;
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMacine) : base(enemy, enemyStateMacine)
    {
        
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Animator.SetTrigger("Run");
        enemy.Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FranmeUpdate()
    {
        base.FranmeUpdate();

        if(enemy.IsWithinStrikingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }

        if(enemy.IsAggored)
        {
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }


        enemy.MoveEnemy(enemy.Target.transform.position, chaseSpeed);

        if (timer >= _aggroedTime)
            enemy.StateMachine.ChangeState(enemy.IdleState);

        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
