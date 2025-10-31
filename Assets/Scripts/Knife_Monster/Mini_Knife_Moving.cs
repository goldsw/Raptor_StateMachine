using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.AI;

public class Mini_Knife_Moving : Knife_Moving
{
    protected override void SetUp()//오버라이드
    {
        NavAgentManager.Mine_rapters_move += Find_path_in_range;
        agent = GetComponent<NavMeshAgent>();
        //Find_path_in_range();
    }

    public override void Find_path_in_range()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        Set_Move_Destination(transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Random.Range(min_move_range, max_move_range));
    }

}