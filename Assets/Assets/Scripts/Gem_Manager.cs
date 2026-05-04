using UnityEngine;
using TMPro;

public class GemManager : MonoBehaviour
{
    public int totalGems = 0;
    public TMP_Text gemText;

    void Start()
    {
        UpdateUI();
    }

    public void AddGems(int amount)
    {
        totalGems += amount;
        UpdateUI();
    }

    public void RemoveGems(int amount)
    {
        totalGems -= amount;

        if (totalGems < 0)
            totalGems = 0;

        UpdateUI();
    }

    void UpdateUI()
    {
        gemText.text = totalGems.ToString();
    }
}