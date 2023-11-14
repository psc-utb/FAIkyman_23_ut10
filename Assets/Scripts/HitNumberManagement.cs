using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitNumberManagement : MonoBehaviour
{
    [SerializeField]
    GameObject hitNumberPrefab;

    public void CreateHitNumber(GameObject character, int hitNumber)
    {
        GameObject go = Instantiate(hitNumberPrefab);

        go.transform.position = character.transform.position;

        TextMeshPro textMeshPro = go.GetComponent<TextMeshPro>();

        textMeshPro.text = string.Empty;
        if (hitNumber > 0)
        {
            textMeshPro.color = Color.green;
            textMeshPro.text = "+";
        }
        else if(hitNumber < 0)
        {
            textMeshPro.color = Color.red;
        }
        else
        {
            textMeshPro.color = Color.blue;
        }
        textMeshPro.text += hitNumber;


        Rigidbody2D rigidBody2D = go.GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = new Vector2(0, 2);


        Destroy(go, 2);
    }
}
