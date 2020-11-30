using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cusumano Cristian Ariel
//28/11/2020


public class BoidManager : MonoBehaviour
{
    public static BoidManager Instance;
    [Header("SpawnParameters")]
    [SerializeField]
    private GameObject BoidPrefab;

    [Header("WaypointDate")]
    public Transform Waypoints;
    private int WaypointIndex = 0;
    public Vector3 ActualWaypoint;

    [Header("Lists")]
    public List<SteerBehaviour> SteerBehaviours;
    public List<BoidUtil> BoidList;
    public List<GameObject> MenaceList;
    public List<GameObject> FoodList;
    public List<Vector3> WaypointsList;

    void Awake()
    {
        Instance = this;
        BoidList = new List<BoidUtil>();
        MenaceList = new List<GameObject>();
        FoodList = new List<GameObject>();
        WaypointsList = new List<Vector3>();
    }

    void Start()
    {
        for (int i = 0; i < Waypoints.childCount; i++)
        {
            WaypointsList.Add(Waypoints.GetChild(i).position);
        }

        ActualWaypoint = WaypointsList.ToArray()[WaypointIndex];
    }

    void Update()
    {
        foreach (BoidUtil _boid in BoidList)
        {
            foreach (SteerBehaviour Steer in SteerBehaviours)
            {
                _boid.velocity += Steer.GetForce(BoidList, _boid, _boid.maxSpeed, FoodList, MenaceList, ActualWaypoint) * Steer.weight * Time.deltaTime;
                _boid.velocity = _boid.VelocityLimiter(_boid.velocity, _boid.maxSpeed);
                float distace = Vector3.Distance(_boid.transform.position, ActualWaypoint);
                if (distace < 1f)
                {
                    WaypointIndex++;
                    WaypointIndex = WaypointIndex >= WaypointsList.Count ? 0 : WaypointIndex;
                    ActualWaypoint = WaypointsList.ToArray()[WaypointIndex];
                }
            }
            _boid.transform.position += _boid.velocity * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
            Spawn();

    }

    void Spawn()
    {
        GameObject thisBoid = Instantiate(BoidPrefab, Vector3.zero, Quaternion.identity);
        BoidList.Add(thisBoid.GetComponent<BoidUtil>());
    }

    public static BoidManager Get()
    {
        return Instance;
    }
}
