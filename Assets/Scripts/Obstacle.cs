using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -1000)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("Hit");
        }
    }
}
