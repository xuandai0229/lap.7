using System.Collections;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public GameObject brokenEggPrefab;  // Prefab của trứng vỡ
    public float destroyDelay = 0.5f;   // Thời gian trễ trước khi xóa trứng vỡ

    private GameManager gameManager;    // Tham chiếu đến GameManager

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Trứng được hứng
        {
            gameManager.AddScore(); // Cộng điểm
            Destroy(gameObject);    // Xóa trứng
        }
        else if (other.CompareTag("Ground")) // Trứng rơi xuống đất
        {
            gameManager.AddMiss(); // Tăng số trứng bị vỡ
            StartCoroutine(BreakEggEffect());
        }
    }

    private IEnumerator BreakEggEffect()
    {
        GameObject brokenEgg = Instantiate(brokenEggPrefab, transform.position, Quaternion.identity);
        brokenEgg.transform.localScale = Vector3.zero;

        float elapsedTime = 0f;
        while (elapsedTime < destroyDelay)
        {
            brokenEgg.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / destroyDelay);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(brokenEgg);
        Destroy(gameObject); // Xóa trứng
    }
}
