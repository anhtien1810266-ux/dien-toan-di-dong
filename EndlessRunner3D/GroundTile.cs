using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject obstaclePrefab; // Rào chắn
    public GameObject coinPrefab;     // Đồng xu
    public Transform[] spawnPoints;   // 3 điểm làn đường

    private void Start()
    {
        SpawnObstacle();
        SpawnCoins();
    }

    void SpawnObstacle()
    {
        // 50% tỉ lệ sinh rào chắn
        if (Random.value > 0.5f && spawnPoints.Length > 0)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(obstaclePrefab, spawnPoints[index].position, Quaternion.identity, transform);
        }
    }

    void SpawnCoins()
    {
        int coinsToSpawn = 2; // Số đồng xu sinh ra trên mỗi mẩu đường
        for (int i = 0; i < coinsToSpawn; i++)
        {
            // Tọa độ ngẫu nhiên trên bề mặt mẩu đường dài 10
            Vector3 spawnPos = new Vector3(
                Random.Range(-3f, 3f),
                1f, // Độ cao ngang thân người
                transform.position.z + Random.Range(1f, 9f)
            );
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GroundSpawner.Instance.SpawnTile();
            Destroy(gameObject, 2f);
        }
    }
}