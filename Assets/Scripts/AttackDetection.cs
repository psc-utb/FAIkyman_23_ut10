using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterBehavior attacker = this.gameObject.GetComponentInParent<CharacterBehavior>();
        CharacterBehavior opponent = collision.gameObject.GetComponent<CharacterBehavior>();
        
        if (attacker != null && opponent != null)
        {
            if(opponent.IsAlive())
                attacker.Attack(opponent);
        }
    }
}
