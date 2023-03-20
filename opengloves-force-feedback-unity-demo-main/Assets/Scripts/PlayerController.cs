using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public SteamVR_Action_Vector2 input2;
    public float speed = 1;
    public float turnSpeed = 45f;
    private CharacterController characterController;
    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(input.axis.x, 0, input.axis.y));
        characterController.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up)-new Vector3(0,9.81f,0)*Time.deltaTime);
        if (input2.axis.x > 0.2f || input2.axis.x < -0.2f)
        {
            // Calculate the angle to turn based on input2 axis
            float turnAmount = input2.axis.x * turnSpeed;

            // Smoothly rotate the player over time
            // Pivot the player on their current position
            transform.RotateAround(transform.position, Vector3.up, turnAmount * Time.deltaTime);
        }
    }
}
