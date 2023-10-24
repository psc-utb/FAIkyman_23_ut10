using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragonAI : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    float distanceToAttack = 0.5f;

    [SerializeField]
    float speed = 3;


    Animator _animator;
    Rigidbody2D _rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    float _directionToTarget;
    bool isAttacking = false;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = target.transform.position.x - this.transform.position.x;
            _directionToTarget = Mathf.Sign(distance);

            if (Mathf.Abs(distance) > distanceToAttack && isAttacking == false)
            {
                _animator.SetBool("Moving", true);
                _rigidBody2D.velocity = new Vector2(_directionToTarget * speed, _rigidBody2D.velocity.y);
            }
            else if (isAttacking == false)
            {
                _animator.SetBool("Moving", false);
                _rigidBody2D.velocity = new Vector2(0, _rigidBody2D.velocity.y);

                _animator.SetTrigger("Attack");
                isAttacking = true;
            }
        }
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    void LateUpdate()
    {
        if (transform.localScale.x > 0
            //&& _rigidBody2D.velocity.x < 0
            && _directionToTarget < 0
           ||
           transform.localScale.x < 0
            //&& _rigidBody2D.velocity.x > 0)
            && _directionToTarget > 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
