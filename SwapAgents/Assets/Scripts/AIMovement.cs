using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject objectToSeek;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] bool bSeeking = true;
    [SerializeField] float wanderRadius;
    Vector3 WanderVector = Vector3.forward;
    [SerializeField] float jitter = 5;

    [SerializeField] GameObject gameObjectToDrive;
    [SerializeField] GameObject objectToSwitchTo;

    private enum Behavior { wander };

    // Start is called before the first frame update
    void Start()
    {
        SwapDriveForGameObject(gameObjectToDrive);
    }

    public void SwapDriveForGameObject(GameObject gameObjectToSwitchTo)
    {
        gameObjectToDrive = gameObjectToSwitchTo;
        rb = gameObjectToDrive.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        ApplyBehavior();
    }

    private Vector3 CalculateSteeringForce()
    {
        //normalized difference between target and agent, times max;
        Vector3 desiredVelocity = (objectToSeek.transform.position - transform.position).normalized * maxSpeed;
        Vector3 steeringForce = desiredVelocity - rb.velocity;// desired velocity minus current
        return steeringForce;
    }

    [SerializeField] Behavior behavior;
    void ApplyBehavior()
    {
        switch (behavior)
        {
            case Behavior.wander:
                Wander();
                break;
            default:
                break;
        }

        //clamping the speed
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * ArrivalBehavior();
        }
    }

    float ArrivalDistance = 2.0f;
    float ArrivalBehavior()
    {
        float velocityClamp = Vector3.Distance(transform.position, objectToSeek.transform.position);
        return (velocityClamp < ArrivalDistance) ? 1.0f : maxSpeed;

    }

    private void Wander()
    {
        Vector3 newtarget = Random.insideUnitSphere;
        newtarget += Random.insideUnitSphere;// * jitter;

        newtarget = new Vector3(newtarget.x, 0.0f, newtarget.z);     
        newtarget.Normalize();
        newtarget = newtarget * wanderRadius;

        newtarget += transform.forward * Random.Range(1f, jitter);     
        rb.AddForce(newtarget);     
    }

}
