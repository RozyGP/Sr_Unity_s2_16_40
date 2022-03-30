using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundMask;

    [SerializeField]
    float speed = 12f;

    Vector3 velocity;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal"),
            z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z; // moving with object's rotation
        //Vector3 move = Vector3.right * x + Vector3.forward * z; // ignore rotation
        characterController.Move(move * speed * Time.deltaTime);

        RaycastHit raycastHit;
        if (Physics.Raycast(
            groundCheck.position, 
            transform.TransformDirection(Vector3.down), 
            out raycastHit, 
            0.4f, 
            groundMask)
            )
        {
            string terrainType = raycastHit.collider.gameObject.tag;
            switch(terrainType)
            {
                case "Low":
                    speed = 3;
                    break;
                case "High":
                    speed = 20;
                    break;
                default:
                    speed = 12;
                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PickUp")
            hit.gameObject.GetComponent<PickUp>().Picked();
    }
}
