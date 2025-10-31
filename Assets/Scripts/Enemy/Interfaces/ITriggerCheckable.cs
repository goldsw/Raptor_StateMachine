using UnityEngine;

public interface ITriggerCheckable
{
    bool IsAggored { get; set; }
    bool IsWithinStrikingDistance { get; set; }

    void SetAggroStatus(bool isAggroed);
    void SetStrikingDistanceBool(bool isWithinStrikingDistance);
}
