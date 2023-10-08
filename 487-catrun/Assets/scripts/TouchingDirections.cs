using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    Animator animator;
    public ContactFilter2D castFilter;
    public float groundDistance = 0.05f;

    private bool _isGrounded = true;

    [SerializeField]
    public bool IsGrounded { 
        get 
        { 
            return _isGrounded; 
        } 
        private set 
        { 
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        } 
    }

    CapsuleCollider2D touchingCol;
    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
      IsGrounded =  touchingCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }
}
