using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rigidBody2D;

    [SerializeField]
    [Tooltip("horizontal speed")]
    //[Range(0, 10)]
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        //utok
        if (Input.GetButton("Fire1") && isAttacking == false)
        {
            _animator.SetTrigger("Attack");
            isAttacking = true;
        }

        //horizontalni pohyb
        float vx = Input.GetAxisRaw("Horizontal");

        if(vx != 0)
        {
            _animator.SetBool("Moving", true);
            _rigidBody2D.velocity = new Vector2(vx * speed, _rigidBody2D.velocity.y);
        }
        else
        {
            _animator.SetBool("Moving", false);
            _rigidBody2D.velocity = new Vector2(0, _rigidBody2D.velocity.y);
            //_rigidBody2D.velocity = Vector2.zero;
        }
    }


    void LateUpdate()
    {
        if (transform.localScale.x > 0 
            && _rigidBody2D.velocity.x < 0
           ||
           transform.localScale.x < 0
            && _rigidBody2D.velocity.x > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }


    public void StopAttacking()
    {
        isAttacking = false;
    }
}
