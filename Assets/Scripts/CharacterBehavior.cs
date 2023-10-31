using CodeMonkey.HealthSystemCM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour, IGetHealthSystem
{
    [SerializeField]
    CharacterUnity character;

    HealthSystem healthSystem;

    void Awake()
    {
        healthSystem = new HealthSystem(character.MaxZdravi);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
