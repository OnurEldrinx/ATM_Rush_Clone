using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerInputs PlayerInputs;
    private float speed = 10f;
    private Vector3 movement;
    private float xBound = 4;

    private void Awake()
    {

        PlayerInputs = new PlayerInputs();

    }

    

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        Move();

    }

    public void Move()
    {

        

        AutoMoveForward();

        Vector2 inputVector = PlayerInputs.Player.Movement.ReadValue<Vector2>();

        movement = new Vector3(inputVector.x,0,0);

        transform.Translate(movement * speed * Time.deltaTime);

        BoundaryCheck();



    }

    private void AutoMoveForward()
    {

        transform.Translate(Vector3.forward * (speed/2) * Time.deltaTime);

    }

    private void BoundaryCheck()
    {


        if (transform.position.x <= -xBound)
        {

            transform.position = new Vector3(-xBound,transform.position.y,transform.position.z);

        }else if(transform.position.x >= xBound)
        {

            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);

        }


        

    }


    private void OnEnable()
    {

        PlayerInputs.Enable();

    }

    private void OnDisable()
    {

        PlayerInputs.Disable();

    }

}
