using CodeMonkey.HealthSystemCM;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{
    [SerializeField]
    CharacterUnity character;

    HealthSystem healthSystem;

    public UnityEvent<GameObject> Dead;

    void Awake()
    {
        healthSystem = new HealthSystem(character.MaxZdravi);

        character.ZdraviZmeneno += Character_ZdraviZmeneno;
    }

    public bool IsAlive()
    {
        return character.JeZiva();
    }

    private void Character_ZdraviZmeneno(int arg1, int arg2)
    {
        //vykreslovat cislo zasahu


        if (character.JeZiva() == false)
        {
            Dead?.Invoke(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    public void Attack(CharacterBehavior opponent)
    {
        int attackValue = character.Utok(opponent.character);
        opponent.healthSystem.SetHealth(opponent.character.Zdravi);
    }
}
