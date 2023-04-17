using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int maxEnemies = 10;
    public float bounds = 0.9f;

    public GameObject planePrefab;

    [SerializeField] private Stats _gui;

    private void Start()
    {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            Instantiate(planePrefab, RandomPos() * new Vector3(1,1,0), Quaternion.Euler(0, 0, 0));
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            _gui.Score();
            Instantiate(planePrefab, RandomPos() * new Vector3(1,1,0), Quaternion.Euler(0, 0, 0));
        }
    }

    private Vector2 RandomPos()
    {
        return Camera.main.ViewportToWorldPoint(new Vector2(Random.Range(1 - bounds, bounds), Random.Range(1 - bounds, bounds)));
    }
}
