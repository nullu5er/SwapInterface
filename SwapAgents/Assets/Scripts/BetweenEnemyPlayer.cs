using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Alignment", menuName = "SwapAgents/BetweenEnemyPlayer")]
public class BetweenEnemyPlayer : BehaviorBase
{
    public override Vector3 GetForce(GameObject[] gameObjectReferences)
    {
        //Vector3 vecBetweenReferences = (gameObjectReferences[2].transform.position - gameObjectReferences[1].transform.position) / 2;
        //Vector3 vecToMidpoint = (vecBetweenReferences - gameObjectReferences[0].transform.position) * weight;

        Vector3 vecBetweenReferences = (gameObjectReferences[2].transform.position - gameObjectReferences[1].transform.position) / 2;
        Vector3 vecToMidpoint = gameObjectReferences[1].transform.position + vecBetweenReferences;
        Vector3 playerToMidpoint = (vecToMidpoint - gameObjectReferences[0].transform.position).normalized;
        playerToMidpoint = playerToMidpoint * weight;

        return playerToMidpoint;

    }
}
