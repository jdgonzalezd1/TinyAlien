using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float energy;
    public int stage;
    float xMov, yMov;
    bool dashButton;
    [SerializeField] float movementSpeed;
    [SerializeField] float turnSpeed;    
    // Start is called before the first frame update
    void Start()
    {
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");
        dashButton = Input.GetKeyDown(KeyCode.Space);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {        
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * yMov);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * xMov);
    }

    void ModifySize()
    {

    }

    void AbsorbObject()
    {

    }

    void TakeDamage()
    {

    }

    void ModifyStage()
    {

    }

    void Dash()
    {
        
    }
}
