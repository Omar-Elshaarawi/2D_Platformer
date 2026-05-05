using UnityEngine;
using TMPro;

public class FinishFlag : MonoBehaviour
{
    public GameObject winScreen;
    public TMP_Text scoreText;

    private GemManager gemManager;

    private void Start()
    {
        gemManager = FindObjectOfType<GemManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("YOU WIN");

            // 👉 Show score
            if (scoreText != null && gemManager != null)
            {
                scoreText.text = "Score: " + gemManager.totalGems;
            }

            // 👉 Show win screen
            if (winScreen != null)
            {
                winScreen.SetActive(true);
            }

            Time.timeScale = 0f;
        }
    }
}