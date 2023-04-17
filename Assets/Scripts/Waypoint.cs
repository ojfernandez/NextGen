using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public float bounds = 15f;

    private Color fade;
    private float fadeDeg;
    private bool intang;

    [SerializeField] private Ways _ways;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        fade = GetComponent<SpriteRenderer>().color;
        fadeDeg = _ways.GetFadeDeg();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void MovePoint()
    {
        transform.position = RandomPos();
        fade.a = 1;
        this.GetComponent<SpriteRenderer>().color = fade;
    }

    private Vector2 RandomPos()
    {
        Vector2 scrnBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        float newPosX = transform.position.x + Random.Range(-bounds, bounds);
        float newPosY = transform.position.y + Random.Range(-bounds, bounds);

        return new Vector2(Mathf.Clamp(newPosX,-scrnBounds.x, scrnBounds.x), Mathf.Clamp(newPosY, -scrnBounds.y, scrnBounds.y));
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.CompareTag("Projectile") && !intang)
        {
            Debug.Log("Splat!");
            fade.a -= fadeDeg;
            if (fade.a <= 0)
            {
                MovePoint();
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = fade;
            }
        }
    }

    public void Hidden(bool active)
    {
        intang = active;
    }
}
