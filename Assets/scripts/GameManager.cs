using UnityEngine;
using TMPro;  // Đảm bảo đã import TextMesh Pro
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;     // Điểm trứng hứng
    public TMP_Text missText;      // Điểm trứng rơi
    public TMP_Text resultText;    // Hiển thị thắng/thua
    public int score = 0;
    public int miss = 0;
    public int goal = 10;          // Mục tiêu hứng
    public int maxMiss = 3;        // Giới hạn trứng rơi

    public GameObject nextLevelButton; // Nút qua màn

    private void Start()
    {
        // Cập nhật UI ban đầu
        UpdateUI();

        // Ẩn nút qua màn ngay khi game bắt đầu
        nextLevelButton.SetActive(false);

        // Ẩn các thông báo kết quả
        resultText.gameObject.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        CheckWin();  // Kiểm tra nếu đã thắng
        UpdateUI();
    }

    public void AddMiss()
    {
        miss++;
        CheckLose();  // Kiểm tra nếu đã thua
        UpdateUI();
    }

    private void CheckWin()
    {
        if (score >= goal)
        {
            Time.timeScale = 0;  // Dừng game
            resultText.text = $"You Win!\nScore: {score}\nMissed: {miss}";
            resultText.color = Color.green;
            resultText.gameObject.SetActive(true);

            // Hiển thị nút qua màn khi thắng
            nextLevelButton.SetActive(true);
        }
    }

    private void CheckLose()
    {
        if (miss >= maxMiss)
        {
            Time.timeScale = 0;  // Dừng game
            resultText.text = $"You Lose!\nScore: {score}\nMissed: {miss}";
            resultText.color = Color.red;
            resultText.gameObject.SetActive(true);

            // Hiển thị nút qua màn khi thua
            nextLevelButton.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {score}";
        missText.text = $"Miss: {miss}";
    }

    public void NextLevel()
    {
        Time.timeScale = 1;  // Tiếp tục game
        score = 0;  // Reset điểm
        miss = 0;   // Reset số trứng rơi
        goal = Mathf.Min(20, goal + 5);  // Tăng mục tiêu hứng trứng (có thể dừng tại 20)
        maxMiss = Mathf.Max(1, maxMiss - 1);  // Giảm số trứng được phép rơi, tối thiểu 1
        nextLevelButton.SetActive(false);  // Ẩn nút qua màn khi qua màn
        resultText.gameObject.SetActive(false);  // Ẩn kết quả
        UpdateUI();  // Cập nhật UI
    }
}
