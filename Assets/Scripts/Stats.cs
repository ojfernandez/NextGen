using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stats;

    private int destroyed = 0;
    private string mode;
    private string point;

    void Start()
    {
        _stats.text = "Eggs: \nDestroyed: \nDrive Mode: \nWaypoint Mode: ";
    }

    void Update()
    {
        _stats.text = " Eggs: " + GameObject.FindGameObjectsWithTag("Projectile").Length +
                      "\n Destroyed: " + destroyed.ToString() +
                      "\n Drive Mode: " + mode + 
                      "\n Waypoint Mode: " + point;
    }

    public void Score()
    {
        destroyed++;
    }

    public void DriveMode(bool mouse)
    {
        if (mouse)
        {
            mode = "Mouse";
        }
        else
        {
            mode = "Keys";
        }
    }

    public void WaypointMode(bool waypoint)
    {
        if (waypoint)
        {
            point = "Sequence";
        }
        else
        {
            point = "Random";
        }
    }
}
