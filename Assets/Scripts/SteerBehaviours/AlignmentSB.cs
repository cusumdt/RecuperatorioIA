using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class AlignmentSB : SteerBehaviour
{
    public override Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 velocity = Vector3.zero;
        int unitsCount = 0;

        foreach (BoidUtil _boid in nearUnits)
        {
            if (actualBoid == _boid)
                continue;

            Vector3 diff = actualBoid.transform.position - _boid.transform.position;
            float distance = diff.magnitude;

            if (distance < radius)
            {
                unitsCount++;
                velocity += _boid.velocity;
            }
        }

        var result = (velocity / unitsCount) - actualBoid.velocity;
        return unitsCount > 0 ? result : Vector3.zero;

    }
}
