using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;

    public float deathY = -10f;
    public GameObject deathScreen;

    public AudioSource deathSound;
    public AudioSource backgroundMusic; // NEW

    private Vector3 spawnPoint;
    private bool isDead = false;

    private List<Gem> collectedGems = new List<Gem>();
    private int gemsCollectedSinceRespawn = 0;

    void Start()
    {
        spawnPoint = transform.position;
        UpdateHearts();

        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }

        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            backgroundMusic.spatialBlend = 0f;
            backgroundMusic.Play();
        }

        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isDead) return;

        if (transform.position.y < deathY)
        {
            TakeDamage();

            if (health > 0)
            {
                Respawn();
            }
        }
    }

    public void TakeDamage()
    {
        if (isDead || health <= 0) return;

        health--;
        UpdateHearts();

        if (health <= 0)
        {
            Die();
        }
    }

    public void TrackCollectedGem(Gem gem)
    {
        if (!collectedGems.Contains(gem))
        {
            collectedGems.Add(gem);
            gemsCollectedSinceRespawn += gem.gemValue;
        }
    }

    void Respawn()
    {
        GemManager gm = FindObjectOfType<GemManager>();

        if (gm != null)
        {
            gm.RemoveGems(gemsCollectedSinceRespawn);
        }

        foreach (Gem gem in collectedGems)
        {
            if (gem != null)
            {
                gem.gameObject.SetActive(true);
            }
        }

        collectedGems.Clear();
        gemsCollectedSinceRespawn = 0;

        transform.position = spawnPoint;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < health;
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log("Player died");

        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        if (deathSound != null)
        {
            deathSound.ignoreListenerPause = true;
            deathSound.spatialBlend = 0f;
            deathSound.volume = 1f;
            deathSound.Play();
        }

        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }

        PlatformerPlayer movement = GetComponent<PlatformerPlayer>();

        if (movement != null)
        {
            movement.enabled = false;
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}