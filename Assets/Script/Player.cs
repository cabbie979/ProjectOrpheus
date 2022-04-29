using EasyJoystick;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Animator animator;

    private Vector2 _dirrection = Vector2.zero;

    private Rigidbody2D _rigidbody = null;
    private Animator _animator = null;

    private string _currentAnimation;
   

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>().GetComponent<Joystick>();
    }

    

    private void FixedUpdate()
    { 
        Movement();
        
    }

   private void ChangeAnimation(string animation)
    {
        if (_currentAnimation == animation) return;

        animator.Play(animation);
        _currentAnimation = animation;
    }

    private void Movement()
    {
        float xMovement = joystick.Horizontal();
        float yMovement = joystick.Vertical();

        _dirrection.x = xMovement;
        _dirrection.y = yMovement;
        if (_dirrection != Vector2.zero)
        {
            _rigidbody.MovePosition(_rigidbody.position + _speed * Time.fixedDeltaTime * _dirrection);
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
       
        

        if(_dirrection != Vector2.zero)
        {
            animator.SetFloat("xInput", _dirrection.x);
            animator.SetFloat("yInput", _dirrection.y);
        }

    }

   
}
