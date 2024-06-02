using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] Transform leftEdge, rightEdge;
    private float relativePosition = 0.5f;


    private float relativeDirection = 0.0f;
    [SerializeField] private float sensitivity = 1f;
        void Update()
    {
        
        relativePosition = Mathf.Clamp(relativePosition += sensitivity*relativeDirection*Time.deltaTime, 0.0f, 1.0f);
        transform.position = Vector3.Lerp(leftEdge.position, rightEdge.position, relativePosition)*7;
    }
    void Awake ()
    {
        playerMovement = new PlayerMovement();
    }
    PlayerMovement playerMovement;
    private void OnEnable()
    {
        playerMovement.Enable();    
    }
private void OnDisable()
{
    playerMovement.Disable();
        
    }
    void Start()
    {
        playerMovement.InGame.movement.started += ChangeInput;
        playerMovement.InGame.movement.canceled += ChangeInput;

    }
    private void ChangeInput(InputAction.CallbackContext context){
        relativeDirection = context.ReadValue<Vector2>().x;

}
}
