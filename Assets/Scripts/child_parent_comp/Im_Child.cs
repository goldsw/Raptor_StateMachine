using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Im_Child : MonoBehaviour
{
    [SerializeField]
    Enemy m_Enemy;
    [SerializeField]
    stand_slot stand_pos;
    [SerializeField]
    float find_range = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Enemy = GetComponent<Enemy>();
        //StartCoroutine(test());

    }
    void Update()
    {
        if (stand_pos && !m_Enemy.IsAggored) //만약 부모가 연결되면 무브 컴포넌트에서 에이전트 매니저와 델리게이트를 끊고 업데이트마다 아래 코드 실행
        {
            m_Enemy.isFindParent = true;// <- 임시 코드 지우셈
            m_Enemy.MoveEnemy(stand_pos.transform.position, 4f);
            return;
        }

        (Im_Parant, float) obj_and_dst = ParentsManager.Search_Parent(transform.position);
        if (find_range >= obj_and_dst.Item2 && !stand_pos)
        {
            if (obj_and_dst.Item1 == null)
                return;
            stand_pos = obj_and_dst.Item1.Find_Stand_slots(this);

        }
    }


    //IEnumerator test() 안돼네
    //{
    //    while (true)
    //    {
    //        if (stand_pos != null) //만약 부모가 연결되면 무브 컴포넌트에서 에이전트 매니저와 델리게이트를 끊고 업데이트마다 아래 코드 실행
    //        {
    //            movecomp.Set_Move_Destination(stand_pos.gameObject.transform.position);
    //            continue;
    //        }
    //        //튜플에서 튜플로 전달이 안돼. float(거리)는 전달되는데 Im_Parant 는 전달이 안됨
    //        (Im_Parant, float) obj_and_dst = ParentsManager.Search_Parent(transform.position);
    //        if (find_range >= obj_and_dst.Item2)
    //        {
    //            if (obj_and_dst.Item1 == null)
    //                continue;

    //            stand_pos = obj_and_dst.Item1.Find_Stand_slots(this);
    //            if (stand_pos != null)
    //            {

    //                //이벤트...
    //            }

    //        }
    //        yield return new WaitForEndOfFrame();

    //    }

    //}

    //부모가 죽으면 여기서 무브 컴포넌트와 다시 연결할 것임. 델리게이트 이벤트.
    /*
     * func....
     */



}
