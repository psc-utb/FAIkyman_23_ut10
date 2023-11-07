using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraManagement : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveCameraAfterDragonDead(GameObject character)
    {
        _animator.SetTrigger("DragonDead");
    }
}
