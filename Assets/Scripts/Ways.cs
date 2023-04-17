using System.Collections.Generic;
using UnityEngine;

public class Ways : MonoBehaviour
{
    public float fadeDeg = 0.25f;
    public bool sequence = true;
    public bool active = true;

    [SerializeField] private Stats _gui;

    private List<GameObject> waypoints;

    void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        waypoints = new List<GameObject>();
        foreach (Transform child in children)
        {
            waypoints.Add(child.gameObject);
            Debug.Log(child.name);
        }
        _gui.WaypointMode(active);
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            sequence = !sequence;
            _gui.WaypointMode(sequence);
        }
        if (Input.GetKeyDown("h"))
        {
            active = !active;

            for (int i = 1; i < waypoints.Count; i++)
            {
                Debug.Log(i + " = " + waypoints[i].name);
                waypoints[i].GetComponent<SpriteRenderer>().enabled = active;
                waypoints[i].GetComponent<Collider2D>().enabled = active;
            }
        }
    }
    
    public GameObject Get_Next_Waypoint(GameObject _cur_waypoint = null)
    {
        if (!sequence)
        {
            return waypoints[Random.Range(1, waypoints.Count-1)];
        }
        
        if (_cur_waypoint == null)
        {
            _cur_waypoint = waypoints[Random.Range(1, waypoints.Count-1)];
        }
        var ind = 1;
        for (int i = 1; i < waypoints.Count; i++)
        {
            if (_cur_waypoint == waypoints[i])
            {
                ind = i;
                i = waypoints.Count + 1;
            }
        }

        if (ind >= waypoints.Count-1)
        {
            ind = 1;
        }
        else
        {
            ind++;
        }
        return waypoints[ind];
    }

    public float GetFadeDeg()
    {
        return fadeDeg;
    }
}
