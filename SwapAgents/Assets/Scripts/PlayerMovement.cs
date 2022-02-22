using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 2.0f;
    [SerializeField] GameObject objectToMove;
    [SerializeField] GameObject objectToSwitchTo;
    [SerializeField] GameObject objectToSwitchToB;
    public bool bVal = true;


    private void Start()
    {

        //objectToMove.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(bVal)
            {
                objectToMove = objectToSwitchTo;
                bVal = false;
            }
            else
            {
                objectToMove = objectToSwitchToB;
                bVal = true;
            }
            //rb = objectToSwitchTo.GetComponent<Rigidbody>();
        }
        
        float movementV= Input.GetAxis("Vertical") * speed;
        float movementH = Input.GetAxis("Horizontal") * speed;
        
        movementV *= Time.deltaTime;
        movementH *= Time.deltaTime;
        
        objectToMove.transform.Translate(0, 0, movementV);
        objectToMove.transform.Translate(movementH, 0 , 0);


    }
}
