using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 borders;
    [SerializeField] private float spawnInterval;
    [SerializeField] private float spawnMaxScale;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnInterval, spawnInterval);
    }

    private void Spawn()
    {
        var index = Random.Range(0, obstacles.Length);
        var obstacle = Instantiate(obstacles[index], player.position + GenerateSpawnPosition(), Quaternion.identity);
        obstacle.transform.localScale *= Random.Range(1f, spawnMaxScale);
    }

    private Vector3 GenerateSpawnPosition()
    {
        var posX = borders.x;
        posX = Random.Range(-posX, posX);
        var posY = borders.y;
        posY = Random.Range(posY / 2, posY);
        var posZ = borders.z;
        posZ = Random.Range(-posZ, posZ);
        return new Vector3(posX, posY, posZ);
    }
}
