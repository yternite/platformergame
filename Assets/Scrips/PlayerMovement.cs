using System;
using JetBrains.Annotations;
using Unity.Cinemachine;
using Unity.Mathematics;
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
   // public CinemachineInputAxisController axisController;
    public Transform target;
    private quaternion doelRotatie; 
    [SerializeField] private SoundManager soundManager;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveAction.Enable();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
       

       //pakt de camera richtingen en legt ze plat booja
      camVooruit = camera.forward;
      camVooruit.y = 0;
      camVooruit.Normalize();
      
      camRechts = camera.right;
      camRechts.y = 0;
      camRechts.Normalize();
      
      //combo
      richting = camera.forward * moveInput.y + camera.right * moveInput.x;
      //zorgt ervoor dat speler alleen horizontaal meegaat
      richting.y = 0;

     //
      if (richting.magnitude > 0.1)
      {
          //makes it face the targetdirection
          richting.Normalize();
          doelRotatie = quaternion.LookRotation(richting, Vector3.up);
          //zet naar doelobject
          this.gameObject.transform.rotation = doelRotatie;
      }

    }

    private void OnEnable()
    {
        //je kan springen
        jump.Enable();
    }

    private void FixedUpdate()
    {
        if (jump.IsPressed())
        {
            soundManager.SpeelSpring();
            
            if (gameObject.transform.position.y < 25.5)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        
        
        //camera follows with walking
        rb.linearVelocity = new Vector3(richting.x * speed, rb.linearVelocity.y, richting.z * speed);
    }
}


