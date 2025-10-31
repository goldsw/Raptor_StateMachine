using Mono.Cecil;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField]
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public NavMeshAgent AI_Agent { get; set; }
    public bool IsAggored { get; set; }
    public bool IsWithinStrikingDistance { get; set; }
    public Player Target { get; set; }
    public Animator Animator { get; set; }


    #region State Machine Variables

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyAttackState AttackState { get; set; }

    #endregion

    #region Idle Variables

    public float min_move_range = 1f;
    public float max_move_range = 10f;

    #endregion


    #region Attack Variables

    public float damage = 5f;

    #endregion


    #region Attack Variables


    #endregion


    #region Find player ranges

    public float Overlap_Radius = 5f;

    #endregion

    #region 그냥 만들어본거임

    public bool isFindParent = false;

    #endregion


    protected void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }

    protected void Start()
    {
        Animator = GetComponentInChildren<Animator>();

        CurrentHealth = MaxHealth;

        AI_Agent = GetComponent<NavMeshAgent>();

        StateMachine.Initialize(IdleState);

    }
    protected void Update()
    {
        StateMachine.CurrentEnemyState.FranmeUpdate();
    }

    protected void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float _damage)
    {
        CurrentHealth -= _damage;

        if (CurrentHealth <= 0f)
        {
            Die();
        }

    }

    public void Die()
    {

    }

    public void Attack(float _damage)
    {
        Target.Get_Damage(_damage);
    }

    #region Movement funcs

    public void MoveEnemy(Vector3 move_pos, float _speed)
    {
        AI_Agent.speed = _speed;
        AI_Agent.SetDestination(new Vector3(move_pos.x, 0, move_pos.z));
    }

    #endregion

    #region Distance Checks

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggored = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }

    #endregion


    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public void TriggerForAnimation()
    {
        StateMachine.CurrentEnemyState.TriggerForAnimation();
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound


    }
    #endregion

}
