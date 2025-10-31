using UnityEngine;
using UnityEngine.AI;

public interface IEnemyMoveable
{
    NavMeshAgent AI_Agent { get; set; }
    void MoveEnemy(Vector3 move_pos, float _speed);




}
