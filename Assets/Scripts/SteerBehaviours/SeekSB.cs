using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class SeekSB : SteerBehaviour
{
    public override Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 diff = NextWaypoint - actualBoid.transform.position;

        Vector3 velocity = (diff.normalized * maxSpeed) - actualBoid.velocity;

        return velocity;
    }
}
