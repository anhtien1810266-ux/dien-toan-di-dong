using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner Instance;
    public GameObject groundTilePrefab; // Nơi kéo Prefab GroundTile vào
    private Vector3 nextSpawnPoint = Vector3.zero;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Khởi tạo sẵn 15 mẩu đường đầu tiên khi vừa vào game
        for (int i = 0; i < 15; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile()
    {
        // Sinh mẩu đường tại vị trí nextSpawnPoint
        GameObject temp = Instantiate(groundTilePrefab, nextSpawnPoint, Quaternion.identity);

        // Tìm điểm NextSpawnPoint con bên trong mẩu đường để gán vị trí cho mẩu đường kế tiếp
        nextSpawnPoint = temp.transform.Find("NextSpawnPoint").position;
    }
}