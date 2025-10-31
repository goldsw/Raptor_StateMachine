using System.Collections;
using UnityEngine;

public class NavAgentManager : MonoBehaviour
{
    public delegate void AgentMove();

    public static AgentMove Rapters_move;
    public static AgentMove Mine_rapters_move;

    public float rapter_research_time = 1f;
    public float mini_rapter_research_time = 1f;
    void Start()
    {
        StartCoroutine(Move_Rapter_Routin());
        StartCoroutine(Move_Mini_Rapter_Routin());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Move_Rapter_Routin()
    {
        while (true)
        {
            Rapters_move?.Invoke();
            yield return new WaitForSeconds(rapter_research_time);
        }
    }
    IEnumerator Move_Mini_Rapter_Routin()
    {
        while (true)
        {
            Mine_rapters_move?.Invoke();
            yield return new WaitForSeconds(mini_rapter_research_time);
        }
    }

}
