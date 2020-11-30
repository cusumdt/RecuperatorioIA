using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020


public class SeparationSB : SteerBehaviour
{
    public override Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint) 
    {
        Vector3 velocity = Vector3.zero;
        float nearUnitsCount = 0;

        if (nearUnits.Count > 0)
        {
            foreach (BoidUtil _boid in nearUnits)
            {
                if (_boid == actualBoid)
                    continue;

                Vector3 difference = actualBoid.transform.position - _boid.transform.position;
                float distance = Vector3.Distance(actualBoid.transform.position, _boid.transform.position);

           

                if (distance < radius)
                {
                    nearUnitsCount++;
                    if(distance > 0)
                        velocity += difference.normalized / distance;
                }
            }

           
        }

        return nearUnitsCount > 0 ? velocity * maxSpeed : Vector3.zero;
    }
}
