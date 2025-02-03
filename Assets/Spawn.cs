using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Obstacle;
    public float spawnRate = 3;
    public float offset = 3;
    private float timer = 0;
    void Start()
    {
        this.spawnObstacle();
    }

    
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            this.spawnObstacle();
            timer = 0;
        }
        
    }

    private void spawnObstacle()
    {
        float min = transform.position.y - offset;
        float max = min + 2*offset;
        Instantiate(Obstacle, new Vector3(transform.position.x, Random.Range(min, max), 0), transform.rotation);
    }
}
