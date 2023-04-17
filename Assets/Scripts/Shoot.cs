using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public float bulletSpeed = 40f;
    public float cooldown = 0.2f;

    private float nextFire = 0f;

    public Transform firePoint;
    public GameObject eggPrefab;
    public Slider slider;

    void Start()
    {
        slider.maxValue = cooldown;
        slider.value = 0;
    }

    void Update()
    {
        ShootEgg();
        SetVisuals();
    }

    private void ShootEgg()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            GameObject egg = Instantiate(eggPrefab, firePoint.position, firePoint.rotation);
            Physics2D.IgnoreCollision(egg.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Rigidbody2D rb2d = egg.GetComponent<Rigidbody2D>();
            rb2d.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
            Debug.Log("nextFire = " + nextFire);
        }
    }

    private void SetVisuals()
    {
        slider.value = nextFire - Time.time;     
    }
}