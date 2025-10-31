using System.Collections;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    float timer = 0;
    float timeBetweenAttack = 2;
    float damage;


    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMacine) : base(enemy, enemyStateMacine)
    {
        damage = enemy.damage;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.Animator.SetTrigger("Attack");
        Attack(damage);
    }

    public override void EnterState()
    {
        base.EnterState();
        enemy.Animator.SetTrigger("Attack");
        enemy.AI_Agent.isStopped = true;
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.Target = null;       
        enemy.AI_Agent.isStopped = false;

    }

    public override void FranmeUpdate()
    {
        Transform Target = enemy.Target.transform;
        Transform Enemy = enemy.transform;
        base.FranmeUpdate();

            enemy.transform.rotation = Quaternion.Lerp(Enemy.rotation, Quaternion.LookRotation(Target.position - Enemy.position), 0.3f);
        if (enemy.IsWithinStrikingDistance && timer > timeBetweenAttack)
        {
            enemy.Animator.SetTrigger("Attack");
            timer = 0;
        }
        else if(!enemy.IsWithinStrikingDistance && timer > timeBetweenAttack)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
            
        }
        timer += Time.deltaTime;
        
    }

    //IEnumerator Look_The_Target()
    //{
    //    while (true)
    //    {

    //        if (Vector3.Dot(Enemy.forward, Target.position - Enemy.position) >= 0.9f)
    //            break;

    //        yield return new WaitForEndOfFrame();
    //    }

    //}

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerForAnimation()
    {
        base.TriggerForAnimation();
        Attack(damage);
    }

    private void Attack(float _damage)
    {
        enemy.Attack(_damage);
    }
}
