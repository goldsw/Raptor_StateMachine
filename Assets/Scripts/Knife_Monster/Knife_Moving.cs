using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.InputManagerEntry;

public class Knife_Moving : MonoBehaviour
{
    protected NavMeshAgent agent;
    public float min_move_range = 1f, max_move_range = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetUp();
    }

    protected virtual void SetUp()
    {
        NavAgentManager.Rapters_move += Find_path_in_range;
        agent = GetComponent<NavMeshAgent>();
        Find_path_in_range();
    }

    void Move(Vector3 move_destination)
    {
        if (agent.pathPending || agent.remainingDistance > 0.3f)
            return;

        agent.SetDestination(move_destination);
            
    }

    public void Chasing_target(Vector3 target)
    {
        Move(target);
    }

    public virtual void Find_path_in_range()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Set_Move_Destination(transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Random.Range(min_move_range, max_move_range));
    }
    
    public void Set_Move_Destination(Vector3 _Destination)
    {
        Move(_Destination);
    }



}
