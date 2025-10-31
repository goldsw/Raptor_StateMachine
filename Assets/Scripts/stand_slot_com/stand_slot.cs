using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stand_slot : MonoBehaviour
{
    [SerializeField]
    int current_childs;
    [SerializeField]
    int max_child = 0;
    List<Im_Child> Childs = new List<Im_Child>();
    public bool Add_Child(Im_Child child)
    {
        if(Childs.Count < max_child)
        { 
            Childs.Add(child);
            return true;
        }
        else
            return false;
    }

    public bool Delet_child(Im_Child child)
    {
        if (Childs.Contains(child))
        {
            Childs.Remove(child);
            return true;
        }
        else
            return false;
    }







}
