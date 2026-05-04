using UnityEngine;

public class Gem : MonoBehaviour
{
    public int gemValue = 1;

    private GemManager gemManager;

    void Start()
    {
        gemManager = FindObjectOfType<GemManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gemManager != null)
            {
                gemManager.AddGems(gemValue);
            }

            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TrackCollectedGem(this);
            }

            gameObject.SetActive(false);
        }
    }
}