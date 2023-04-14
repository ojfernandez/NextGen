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
        }
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
            for (int i = 0; i < waypoints.Count; i++)
            {
                waypoints[i].GetComponent<Renderer>().enabled = active;
                waypoints[i].GetComponent<Collider2D>().enabled = active;
            }
        }
    }

    public float GetFadeDeg()
    {
        return fadeDeg;
    }
}
