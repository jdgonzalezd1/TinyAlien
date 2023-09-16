using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int energy = 10;
    public int stage;
    public float eatTime;

    [HideInInspector] public Vector3 direction;
    [HideInInspector] public Vector3 scaleChange, positionChange;
    [SerializeField] float movementSpeed;
    bool canMove = true;
    float xMov, zMov;
    float rotateTime;
    float rotateVelocity;


    [SerializeField] GameObject player;
    public CharacterController controller;
    public GameObject alienSmall;
    public GameObject alienMedium;
    public GameObject alienLarge;
    public EnergyBar energyBar;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        scaleChange = new Vector3(0.01f, 0.01f, 0.01f);
        energyBar.SetMaxEnergy(2000);
        energyBar.SetEnergy(energy);
        ModifySize();
        ModifyStage();
    }
    private void FixedUpdate()
    {
        // PlayerMovement();        
    }

    private void Update()
    {
        PlayerMovement();        
        // ModifySize();
    }

    void PlayerMovement()
    {
        xMov = Input.GetAxisRaw("Horizontal");
        zMov = Input.GetAxisRaw("Vertical");
        if (canMove)
        {
            Vector3 dir = new Vector3(xMov, 0, zMov).normalized;

            if (dir.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotateVelocity, rotateTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.SimpleMove(direction.normalized * movementSpeed * Time.deltaTime);
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

    void ModifySize()
    {
        player.transform.localScale = scaleChange * this.energy;
        movementSpeed = 0.7f * this.energy + 145;
        Debug.Log("Energy: " + this.energy);
    }

    public void AbsorbObject(int energy)
    {        
        this.energy += energy;
        energyBar.SetEnergy(this.energy);
        StartCoroutine(Eating());
        energyBar.WinCondition();
        Debug.Log("Energy: " + this.energy);
        ModifySize();
        ModifyStage();
    }


    void TakeDamage()
    {

    }

    void ModifyStage()
    {
        if (energy < 666)
        {
            stage = 1;
            alienSmall.SetActive(true);
            alienMedium.SetActive(false);
        }
        else if (energy >= 666 && energy <= 1333)
        {
            stage = 2;
            alienMedium.SetActive(true);
            alienSmall.SetActive(false);
            alienLarge.SetActive(false);
        }
        else if (energy >= 1334 && energy <= 2000)
        {
            stage = 3;
            alienLarge.SetActive(true);
            alienSmall.SetActive(false);
            alienMedium.SetActive(false);
        }
        Debug.Log("Stage: " + stage);
    }

    IEnumerator Eating()
    {
        float startTime = Time.time;
        while (Time.time < startTime + eatTime)
        {
            animator.SetBool("Eating", true);
            yield return null;
        }
        animator.SetBool("Eating", false);
    }

    public float GetEnergy()
    {
        return this.energy;
    }

    public void SetMovement(bool flag)
    {
        this.canMove = flag;
    }

}
