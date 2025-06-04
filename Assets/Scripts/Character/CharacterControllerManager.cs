using Unity.VisualScripting;
using UnityEngine;

public class CharacterControllerManager : MonoBehaviour
{
    [SerializeField] VariableJoystick variableJoystick;
    [SerializeField] Canvas canvas;

    private Animator animator;
    CharacterController controller;

    [SerializeField] float Movementspeed = 5f;
    [SerializeField] float RotationSpeed = 10f;
    bool isJoystick;

    public float TimeDelayBwAttacks = StaticPlayerItems.TimeBetweenAttacks;
    private float timer = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        EnableJoystick(); // Default input device == Joystick
    }

    private void Update()
    {
        if (TimeDelayBwAttacks != StaticPlayerItems.TimeBetweenAttacks)
        {
            TimeDelayBwAttacks = StaticPlayerItems.TimeBetweenAttacks;
        }
        
        if (isJoystick)
        {
            var movementDir = new Vector3(variableJoystick.Direction.x, 0f, variableJoystick.Direction.y);

            if (movementDir != Vector3.zero)
                animator.SetBool("IsRunning",true);
            else
                animator.SetBool("IsRunning",false);
                

            controller.SimpleMove(movementDir * Movementspeed);
            

            if(movementDir.sqrMagnitude > 0f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDir, Vector3.up), Time.deltaTime * RotationSpeed);
            }
        }

        if (StaticPlayerItems.isAttacking)
        {
            timer += Time.deltaTime;
            if (timer >= TimeDelayBwAttacks)
            {
                Cut();
                timer = 0;
            }
        }
        else
        {
            timer = TimeDelayBwAttacks;
        }

        if (Input.GetKeyDown(KeyCode.Space)) // ekstra
        {
            Cut();
        }
        
        
        
    }

    public void EnableJoystick()
    {
        isJoystick = true;
        canvas.gameObject.SetActive(true);
    }


    public void Cut()
    {
        animator.SetTrigger("Cut");
        Invoke("delayedHitCheck",1f);
    }

    void delayedHitCheck()
    {
        HitareaDetection.instance.CheckHit();
    }
    
}
