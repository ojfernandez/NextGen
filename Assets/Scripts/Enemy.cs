using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;
    public float fadeMulti = 0.8f;
    
   
    private float move_speed = 25f;
    private float rotate_speed = 90f;
    
    private GameObject next_waypoint;
    private Vector3 movement_dir;
    private Ways waypoint_manager;

    private Color fade;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        fade = GetComponent<SpriteRenderer>().color;
        waypoint_manager = GameObject.Find("Waypoints").GetComponent<Ways>();
        next_waypoint = waypoint_manager.Get_Next_Waypoint();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Crash!");
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Projectile"))
        {
            health--;
            Debug.Log("Health = " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                fade.a *= fadeMulti;
                this.GetComponent<SpriteRenderer>().color = fade;
            }
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, next_waypoint.transform.position);
        var dis_threshhold = 10f;
        if (distance > dis_threshhold)
        {
            float angle = Mathf.Atan2(next_waypoint.transform.position.y - transform.position.y, next_waypoint.transform.position.x -transform.position.x ) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotate_speed * Time.deltaTime);
            
            // Move the object in the direction of the move direction
            transform.position += transform.up * move_speed * Time.deltaTime;
        }
        else
        {
            Debug.Log("   ");
            Debug.Log(next_waypoint);
            next_waypoint = waypoint_manager.Get_Next_Waypoint(next_waypoint);
            Debug.Log("Getting next");
            Debug.Log(next_waypoint);
            Debug.Log("   ");
        }
    }
}
