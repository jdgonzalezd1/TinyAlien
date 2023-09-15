using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float energy;
    public int stage;
    float xMov, zMov;
    float rotateTime;
    float rotateVelocity;
    public Vector3 direction;
    public Vector3 scaleChange, positionChange;
    [SerializeField] GameObject player;
    [SerializeField] float movementSpeed;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
    }
    private void FixedUpdate()
    {
        PlayerMovement();        
    }

    void PlayerMovement()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(xMov, 0, zMov).normalized;

        if (dir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotateVelocity, rotateTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.SimpleMove(direction.normalized * movementSpeed * Time.deltaTime);
        }
    }

    void ModifySize()
    {
        player.transform.localScale = scaleChange * this.energy;
    }

    public void AbsorbObject(float energy)
    {
        this.energy += energy;
        Debug.Log("Energy: " + this.energy);
        ModifyStage();
        ModifySize();
    }

    void TakeDamage()
    {

    }

    void ModifyStage()
    {
        if(energy < 100)
        {
            stage = 1;
        }else if (energy >= 100 && energy <= 199)
        {
            stage = 2;
        }else if (energy >= 200 && energy <= 299)
        {
            stage = 3;
        }
        Debug.Log("Stage: " + stage);
    }

}
