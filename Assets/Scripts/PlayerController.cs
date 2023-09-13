using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float energy;
    public int stage;
    float xMov, yMov;
    float rotateAngle;
    bool dashButton;
    [SerializeField] float movementSpeed;
    [SerializeField] GameObject rotationBody;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed * xMov);
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed * yMov);
        rotateAngle = AngleRotation(xMov,yMov);         
        rotationBody.transform.eulerAngles = new Vector3(rotationBody.transform.eulerAngles.x, rotationBody.transform.eulerAngles.y, rotationBody.transform.eulerAngles.z)
        {
            y = rotateAngle
        };
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
        dashButton = Input.GetKeyDown(KeyCode.Space);
    }

    float AngleRotation(float xMov, float yMov)
    {
        if (xMov == 0 && yMov > 0) rotateAngle = 0;
        if (xMov > 0 && yMov > 0) rotateAngle = 45;
        if (xMov > 0 && yMov == 0) rotateAngle = 90;
        if (xMov > 0 && yMov < 0) rotateAngle = 135;
        if (xMov == 0 && yMov < 0) rotateAngle = 180;
        if (xMov < 0 && yMov < 0) rotateAngle = 225;
        if (xMov < 0 && yMov == 0) rotateAngle = 270;
        if (xMov < 0 && yMov > 0) rotateAngle = 315;                    
        return rotateAngle;
    }
}
