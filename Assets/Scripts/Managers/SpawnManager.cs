using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject MenacePrefab;
    public GameObject FoodPrefab;
    [Header("Times")]
    public float LimitTime;
    private float FoodTime;

    [Header("LimitBox")]
    public BoxCollider boxCollision;
    private Bounds BoxBounds;

    void Start()
    {
        FoodTime = LimitTime;
        BoxBounds = boxCollision.bounds;
    }

    void Update()
    {
        FoodTime -= Time.deltaTime;

        if (FoodTime <= 0.0f)
        {
            Spawn(FoodPrefab, "Food");
            FoodTime = LimitTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
            Spawn(MenacePrefab, "Menace");
    }

    void Spawn(GameObject prefab, string tipo)
    {
        GameObject obj = Instantiate(prefab);
        float xPos = Random.Range(BoxBounds.min.x, BoxBounds.max.x);
        float zPos = Random.Range(BoxBounds.min.z, BoxBounds.max.z);
        float yPos = Random.Range(BoxBounds.min.y, BoxBounds.max.y);
        obj.transform.position = new Vector3(xPos, yPos, zPos);

        if (tipo == "Food")
            BoidManager.Get().FoodList.Add(obj);
        else if (tipo == "Menace")
            BoidManager.Get().MenaceList.Add(obj);
    }
}
