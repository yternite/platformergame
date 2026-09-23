using System;
using JetBrains.Annotations;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction jump;
    public float jumpForce = 5f;
    private Rigidbody rb;
    public Vector2 moveInput;
    public InputAction moveAction;
    public float speed = 5f;
    [SerializeField] private Transform camera;
    [SerializeField] private Vector2 camVooruit;
    [SerializeField] private Vector2 camRechts;
    private Vector3 richting;
    public CinemachineInputAxisController axisController;
    public InputAction mouseAction;
    public Transform target;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
        mouseAction.Enable();
    }

    void Update()
    {
        //makes the mouse control the camera if pressed
        if (mouseAction.IsPressed())
        {
            axisController.enabled = true;
        }
        //turns it off when it isnt
        else
        {
            axisController.enabled = false;
            
        }
        
        moveInput = moveAction.ReadValue<Vector2>();
       // *transform.Translate(Vector3.forward * Time.deltaTime * moveInput.y);

       //pakt de camera richtingen en legt ze plat booja
      camVooruit = camera.forward;
      camVooruit.y = 0;
      camVooruit.Normalize();
      
      camRechts = camera.right;
      camRechts.y = 0;
      camRechts.Normalize();
      
      //combo
      richting = camera.forward * moveInput.y + camera.right * moveInput.x;
      
      Vector3 relativePos = target.position - transform.position;
      
     Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
      transform.rotation = rotation; 
    }

    private void OnEnable()
    {
        jump.Enable();
    }

    private void FixedUpdate()
    {
        if (jump.IsPressed())
        {
            Debug.Log("Jump");
            //if its below the air(?) it jumps
            if (gameObject.transform.position.y < 1.5)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        //rb.linearVelocity = new Vector3(moveInput.x * speed, rb.linearVelocity.y, moveInput.y * speed) ;
        
        //camera follows with walking
        rb.linearVelocity = new Vector3(richting.x * speed, rb.linearVelocity.y, richting.z * speed);

    }
}


