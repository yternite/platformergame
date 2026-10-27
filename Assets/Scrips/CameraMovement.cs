using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public InputAction mouseAction;
    public CinemachineInputAxisController axisController;
   
    void Start()
    {
        mouseAction.Enable();
        Debug.Log("mouseaction enabled");
    }
    
    void Update()
    {
        //makes the mouse control the camera if pressed
        if (mouseAction.IsPressed())
        {
            axisController.enabled = true;
        }
        //turns it off when it isn't
        else
        {
            axisController.enabled = false;
            
        }
        
    }
}
