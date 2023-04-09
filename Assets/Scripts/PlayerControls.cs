using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : Character, FireControl
{
    public GameObject projectilePrefab;

    //ENCAPSULTION
    private PlayerController inputActions;
    private InputAction fire;
    private InputAction movement;
    private InputAction jump;
    private float movementSpeed = 10.0f;

    private Rigidbody playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
        inputActions = new PlayerController();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
        jump.Disable();
    }

    private void OnEnable()
    {
        movement = inputActions.Player.Movement;
        movement.Enable();
        jump = inputActions.Player.Jump;
        jump.Enable();
        jump.performed += Jump;
        fire = inputActions.Player.Fire;
        fire.Enable();
        fire.performed += Fire;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = movement.ReadValue<Vector2>();
        transform.Translate(movementSpeed * Time.deltaTime * move);
    }

    //POLYMORPHISM 
    public void Fire(InputAction.CallbackContext context)
    {
        Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), projectilePrefab.transform.rotation);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Jump(playerRB, movementSpeed);
    }
}
