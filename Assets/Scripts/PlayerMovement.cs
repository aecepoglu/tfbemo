using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _facingRight = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        _animator.SetBool("walk", Mathf.Abs(horizontalMove) > 0);
        Debug.Log(horizontalMove);
        if (horizontalMove > 0 && !_facingRight)
        {
            Flip();
        }
        else if (horizontalMove < 0 && _facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, false, false);
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        if (_facingRight && _spriteRenderer.flipX)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}