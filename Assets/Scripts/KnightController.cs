using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //utok
        if (Input.GetButton("Fire1"))
        {
            _animator.SetTrigger("Attack");
        }

        //horizontalni pohyb
        float vx = Input.GetAxisRaw("Horizontal");

        if(vx != 0)
        {
            _animator.SetBool("Moving", true);
        }
        else
        {
            _animator.SetBool("Moving", false);
        }
    }
}
