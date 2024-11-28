using UnityEngine;

public class Basket : MonoBehaviour
{
    public float speed = 10f; // Tốc độ di chuyển
    public float minX = -3.5f, maxX = 3.5f; // Giới hạn di chuyển

    private bool isFacingRight = true; // Basket mặc định quay phải

    void Update()
    {
        // Lấy giá trị từ phím điều khiển
        float move = Input.GetAxis("Horizontal");

        // Di chuyển Basket
        transform.Translate(move * speed * Time.deltaTime, 0, 0);

        // Giới hạn di chuyển trong màn hình
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Lật mặt nếu đổi hướng
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Đổi trạng thái hướng mặt

        // Lật mặt bằng cách thay đổi trục X của localScale
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Đảo chiều trục X
        transform.localScale = localScale;
    }
}
