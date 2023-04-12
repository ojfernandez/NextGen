using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool mouse = false;
    public float speed = 10f;
    public float rotate = 1f;

    private Rigidbody2D rb2d;
    public Stats gui;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gui.DriveMode(mouse);
    }

    void Update()
    {
        if(Input.GetKeyDown("m"))
        {
            rb2d.velocity = Vector3.zero;
            mouse = !mouse;
            gui.DriveMode(mouse);
        }

        if (!mouse)
        {
            
            
            // "w" can be replaced with any key
            // this section moves the character up/jump
            if (Input.GetKey("w"))
            {
                rb2d.AddForce(transform.up * speed);
            }

            // "s" can be replaced with any key
            // this section moves the character down
            else if (Input.GetKey("s"))
            {
                rb2d.AddForce(-transform.up * speed);
            }
        }
        else
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, 0, -1 * rotate);
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, 0, rotate);
        }

        if (Input.GetKey("q"))
        {
            Application.Quit();
        }
    }
}
