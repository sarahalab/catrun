using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    public float currentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                { 
                    return runSpeed; 
                }
                else 
                { 
                    return walkSpeed; 
                }

            }
            else
            {
                return 0; //idle speed is 0
            }
        }
    }

    [SerializeField] // makes variable visible in unity
    private bool _isMoving = false;
    [SerializeField]
    private bool _isRunning = false;
    public bool IsMoving { 
        get 
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }

    private bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight { get { return _isFacingRight; }
        private set
        {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1); //flip the image of the player
            }
            _isFacingRight = value;
        }
    }
    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
       rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * currentMoveSpeed, rb.velocity.y);
    }

   public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); //this makes x and y movements

        IsMoving = moveInput != Vector2.zero; //Is moving is true as long as its not equal to zero

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            //face right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            //face left
            IsFacingRight = false;
        }
    }

    public void onRun(InputAction.CallbackContext context) //'context' regard the pressing of a keyboard button here
    {
        if (context.started) //button is pressed down
        {
            IsRunning = true;
        }
        else if (context.canceled) //button is released
        {
            IsRunning = false;
        }
    }
}
