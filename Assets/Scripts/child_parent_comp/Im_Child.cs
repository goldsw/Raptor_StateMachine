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
        if (stand_pos && !m_Enemy.IsAggored) //���� �θ� ����Ǹ� ���� ������Ʈ���� ������Ʈ �Ŵ����� ��������Ʈ�� ���� ������Ʈ���� �Ʒ� �ڵ� ����
        {
            m_Enemy.isFindParent = true;// <- �ӽ� �ڵ� �����
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


    //IEnumerator test() �ȵų�
    //{
    //    while (true)
    //    {
    //        if (stand_pos != null) //���� �θ� ����Ǹ� ���� ������Ʈ���� ������Ʈ �Ŵ����� ��������Ʈ�� ���� ������Ʈ���� �Ʒ� �ڵ� ����
    //        {
    //            movecomp.Set_Move_Destination(stand_pos.gameObject.transform.position);
    //            continue;
    //        }
    //        //Ʃ�ÿ��� Ʃ�÷� ������ �ȵ�. float(�Ÿ�)�� ���޵Ǵµ� Im_Parant �� ������ �ȵ�
    //        (Im_Parant, float) obj_and_dst = ParentsManager.Search_Parent(transform.position);
    //        if (find_range >= obj_and_dst.Item2)
    //        {
    //            if (obj_and_dst.Item1 == null)
    //                continue;

    //            stand_pos = obj_and_dst.Item1.Find_Stand_slots(this);
    //            if (stand_pos != null)
    //            {

    //                //�̺�Ʈ...
    //            }

    //        }
    //        yield return new WaitForEndOfFrame();

    //    }

    //}

    //�θ� ������ ���⼭ ���� ������Ʈ�� �ٽ� ������ ����. ��������Ʈ �̺�Ʈ.
    /*
     * func....
     */



}
