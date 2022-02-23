using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alignment", menuName = "SwapAgents/CloseCombat")]
public class CloseCombat : BehaviorBase
{
    public override Vector3 GetForce(GameObject[] gameObjectReferences)
    {
        return Vector3.zero;
    }

}
