using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stats;

    private int destroyed = 0;
    private string mode;

    void Start()
    {
        _stats.text = "Eggs: \nEnemies: \nDestroyed: \nDriveMode: ";
    }

    void Update()
    {
        _stats.text = "Eggs: " + GameObject.FindGameObjectsWithTag("Projectile").Length +
                      "\nEnemies: " + GameObject.FindGameObjectsWithTag("Enemy").Length +
                      "\nDestroyed: " + destroyed.ToString() +
                      "\nDrive Mode: " + mode;
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
}
