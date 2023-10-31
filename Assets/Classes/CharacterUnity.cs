using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using hrdina_a_drak.Postavy;
using System;

[Serializable]
public class CharacterUnity : Postava, ISerializationCallbackReceiver
{
    [SerializeField]
    string name;

    [SerializeField]
    int health;

    [SerializeField]
    int maxDamage;

    [SerializeField]
    int maxDefence;

    public CharacterUnity(string jmeno, int zdravi, int maxPoskozeni, int maxObrana)
        : base(jmeno, zdravi, maxPoskozeni, maxObrana)
    {
    }

    public CharacterUnity() : base(default, default, default, default)
    {

    }

    public void OnBeforeSerialize()
    {
        name = Jmeno;
        health = Zdravi;
        maxDamage = MaxPoskozeni;
        maxDefence = MaxObrana;
    }

    public void OnAfterDeserialize()
    {
        Jmeno = name;
        Zdravi = health;
        MaxZdravi = health;
        MaxPoskozeni = maxDamage;
        MaxObrana = maxDefence;
    }
}
