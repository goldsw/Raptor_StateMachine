using Unity.Services.Analytics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyIdleState : EnemyState
{
    private Vector3 _nextPos;
    private float idleSpeed = 5f;
    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMacine) : base(enemy, enemyStateMacine)
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
        _nextPos = GetRandomPointInCricle();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FranmeUpdate()
    {
        base.FranmeUpdate();

        if(enemy.IsAggored)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        _nextPos = GetRandomPointInCricle();
        if (!(enemy.AI_Agent.pathPending || enemy.AI_Agent.remainingDistance > 0.3f) && !enemy.isFindParent)
            enemy.MoveEnemy(_nextPos, idleSpeed);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private Vector3 GetRandomPointInCricle()
    {
        Vector3 next_pos;
        Vector3 liveArea = enemy.transform.position;
        float camera_size = 30f;
        float angle = Random.Range(0, 360) * Mathf.Deg2Rad;
        next_pos = enemy.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Random.Range(enemy.min_move_range, enemy.max_move_range);

        if (
        enemy.transform.position.x > liveArea.x + camera_size ||
        enemy.transform.position.x < liveArea.x - camera_size ||
        enemy.transform.position.z > liveArea.z + camera_size ||
        enemy.transform.position.z < liveArea.z - camera_size
        )
        {
            return next_pos;
        }
        if (
        next_pos.x > liveArea.x + camera_size ||
        next_pos.x < liveArea.x - camera_size ||
        next_pos.z > liveArea.z + camera_size ||
        next_pos.z < liveArea.z - camera_size 
        )
        {
            next_pos = new Vector3(liveArea.x, 0, liveArea.z);
            return next_pos;
        }

        return next_pos;

    }

}
