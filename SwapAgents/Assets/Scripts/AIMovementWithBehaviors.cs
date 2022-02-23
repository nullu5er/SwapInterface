using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementWithBehaviors : MonoBehaviour
{
    public GameObject objectBeingDirected;

    private BehaviorBase[] listOfBehaviors;
    public GameObject[] forceTargets;
    [SerializeField] float maxSpeed = 10;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        listOfBehaviors = objectBeingDirected.GetComponent<GameObjectBehaviors>().behaviors;
        rb = objectBeingDirected.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 force = Vector3.zero;

        //for(int i = 0; i < listOfBehaviors.Length; i++)
        //{
        //    force = listOfBehaviors[i].GetForce(forceTargets);
        //}

        //testing, run the betweenEnemyPlayer behavior
        force = listOfBehaviors[1].GetForce(forceTargets);

        force = force * maxSpeed;
 
        rb.AddForce(force);

    }
}
