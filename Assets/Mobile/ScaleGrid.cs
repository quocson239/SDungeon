using UnityEngine;

public class ScaleGrid : MonoBehaviour
{
    public Grid grid;

    void Start()
    {
        AdjustGridScale();
    }

    void AdjustGridScale()
    {
        // Lấy kích thước màn hình
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Tính toán tỉ lệ
        float scaleX = screenWidth / 1920f; // Thay đổi 1080f thành độ rộng thiết kế ban đầu của bạn
        float scaleY = screenHeight / 1080f; // Thay đổi 1920f thành chiều cao thiết kế ban đầu của bạn

        // Thiết lập tỉ lệ cho Grid
        grid.transform.localScale = new Vector3(scaleX, scaleY, 1);
    }
}