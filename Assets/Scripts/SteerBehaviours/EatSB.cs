using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class EatSB : SteerBehaviour
{
    public override Vector3 GetForce(List<BoidUtil> nearUnits, BoidUtil actualBoid, float maxSpeed, List<GameObject> food, List<GameObject> Menace, Vector3 NextWaypoint)
    {
        Vector3 velocity = Vector3.zero;
        Vector3 foodPosition = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);

        if(food.Count <= 0)
            return Vector3.zero;

        for (int i = 0; i < food.Count; i++)
        {
            float distance = Vector3.Distance(foodPosition, actualBoid.transform.position);
            float otherDistance = Vector3.Distance(food.ToArray()[i].transform.position, actualBoid.transform.position);

            if (otherDistance < distance)
            {
                foodPosition = food.ToArray()[i].transform.position;
            }
        }

        Vector3 diff = foodPosition - actualBoid.transform.position;
        velocity = (diff.normalized * maxSpeed) - actualBoid.velocity;
        return velocity;
    }
}
