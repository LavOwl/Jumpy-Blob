using Unity.VisualScripting;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public UpdateManager logic;
    public AudioSource ding;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<UpdateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addToScore(1);
        ding.Play();
    }
}
