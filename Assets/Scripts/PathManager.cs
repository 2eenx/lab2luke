using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]

    public List<Waypoint> path;

    //x

    public GameObject prefab;
    int currentPointIndex = 0;
    public List<GameObject> prefabPoints;

    public void Start()
    {
        prefabPoints = new List<GameObject>();
        //create prefab colliders
        foreach( Waypoint p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add(go);
        }
    }

    public void Update()
    {
        //update all prefabs to waypoint location
        for (int i = 0; i < path.Count; i++)
        {
            Waypoint p = path[i];
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }

    public Waypoint GetNextTarget()
    {
        int nextPointIndex = (currentPointIndex + 1) % (path.Count);
        currentPointIndex = nextPointIndex;
        return path[nextPointIndex];

    }
    public List<Waypoint> GetPath()
    {
        if (path == null)
            path = new List<Waypoint>();
        
        return path;
    }

    public void CreateAddPoint()
    {
        Waypoint go = new Waypoint();
        path.Add(go);
    }
}
