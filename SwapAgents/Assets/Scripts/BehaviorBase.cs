using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorBase : ScriptableObject
{
    public float weight = 1f;
    public abstract Vector3 GetForce(float maxForce);

}
