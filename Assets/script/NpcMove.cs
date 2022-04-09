using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public float movementSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        float moveAmount = Time.deltaTime * movementSpeed;
        transform.Translate(Vector3.forward * moveAmount);
       
    }
}
