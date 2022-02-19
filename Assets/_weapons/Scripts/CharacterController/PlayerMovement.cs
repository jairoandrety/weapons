using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float gravity = 0; //-9.81f
    [SerializeField] private float jumpHeigth = 0; //3f
    [SerializeField] private CharacterController controller;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private float groundDistance = 0;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private WeaponController weaponController;

    private float x = 0;
    private float z = 0;
    private Vector3 move = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    public WeaponController WeaponController { get => weaponController; set => weaponController = value; }

    void Start()
    { 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            Debug.Log("encontre arma");

            if (Input.GetKeyDown(KeyCode.E))
            {
                weaponController.ChangeWeapon(other.gameObject.GetComponent<Weapon>());
            }            
        }
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * (isGrounded ? speed : speed / 2) * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeigth * -2 * gravity);
        }     

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            weaponController.Shoot();
        }
    }
}
