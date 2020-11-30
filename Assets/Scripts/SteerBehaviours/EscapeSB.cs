using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class EscapeSB : SteerBehaviour
{
    public override Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 velocity = Vector3.zero;

        for (int i = 0; i < Menace.Count; i++)
        {
            Vector3 difference = actualBoid.transform.position - Menace[i].transform.position;
            float distance = Vector3.Distance(actualBoid.transform.position, Menace[i].transform.position);

            if (distance < radius)
            {
                Vector3 pos = Menace[i].transform.position - actualBoid.transform.position;

                velocity = ((pos.normalized * maxSpeed) - actualBoid.velocity) * -1.0f;

                return velocity;
            }
        }
        return Vector3.zero;
    }
}
