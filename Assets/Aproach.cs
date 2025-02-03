using UnityEngine;

public class Aproach : MonoBehaviour
{
    public float movementSpeed = 3;
    public float endOfScreen = -9;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = 3;
        transform.position = transform.position + (Vector3.left * movementSpeed * Time.deltaTime);
        if (transform.position.x < endOfScreen)
        {
            Destroy(gameObject);
        }
    }
}
