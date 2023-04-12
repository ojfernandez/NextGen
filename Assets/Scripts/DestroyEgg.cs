using UnityEngine;

public class DestroyEgg : MonoBehaviour
{
    void Update()
    {
        OffScreen();
    }

    private void OffScreen()
    {
        Vector2 scrnPos = Camera.main.WorldToScreenPoint(transform.position);
        if (scrnPos.x > Screen.width || scrnPos.x < 0 || scrnPos.y > Screen.height || scrnPos.y < 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
            Destroy(this.gameObject);
        }
    }
}
