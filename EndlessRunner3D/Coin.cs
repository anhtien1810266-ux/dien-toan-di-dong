using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f;

    void Update()
    {
        // Tự xoay tròn quanh trục Y để tạo hiệu ứng lấp lánh
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Nếu chẳng may sinh trùng chỗ với rào chắn thì tự biến mất
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            return;
        }

        // Khi nhân vật chạm vào đồng xu
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(1); // Cộng 1 điểm
            }
            Destroy(gameObject); // Xóa đồng xu
        }
    }
}