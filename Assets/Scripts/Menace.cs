using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
// 28 / 11 / 2020

public class Menace : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private Vector3 Direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float xDir = Random.Range(0.01f, 1.0f);
        float yDir = Random.Range(0.01f, 1.0f);
        float zDir = Random.Range(0.01f, 1.0f);
        Direction = new Vector3(xDir,yDir,zDir);
        transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
    }

    void FixedUpdate()
    {
        rb.velocity = Direction * speed * Time.fixedDeltaTime;
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.transform.name == "Collision")
        {
            Direction = -Direction;
            transform.rotation = Quaternion.LookRotation(Direction, Vector3.up);
        }
    }
}
