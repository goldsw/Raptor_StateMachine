using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Im_Parant : MonoBehaviour
{
    //죽었다는 이벤트 보내는 곳
    public List<stand_slot> stand_slots = new List<stand_slot>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ParentsManager.parants.Add(this);
    }

    private void OnDestroy()
    {
        ParentsManager.parants.Remove(this);
    }

    public stand_slot Find_Stand_slots(Im_Child im_Child)
    {
        foreach(stand_slot i in stand_slots)
        {
            if(i.Add_Child(im_Child))
            {
                return i;
            }

        }
        return null;

    }


}
