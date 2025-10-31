using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Drawing;

public class ParentsManager : MonoBehaviour
{
    
    public static List<Im_Parant> parants = new List<Im_Parant>();
    //public static int Add_list(Im_Parant parant)
    //{
    //    parants.Add(parant);
    //    return parants.FindIndex(p => p == parant);
    //}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

//    공용 정적 (나는_부모다, 부호가있는유리수) 부모_찾기(방향량3 _위치)
    public static (Im_Parant, float) Search_Parent(Vector3 _pos)
    {
        Im_Parant parent = null;
        float distance = 100000000000f;
        for (int i = 0; i < parants.Count; i++)
        {
            float dst = (parants[i].transform.position - _pos).magnitude;
            if (dst <= distance)
            {
                parent = parants[i];
                distance = dst;
            }

        }
        return (parent, distance);
    }


}
