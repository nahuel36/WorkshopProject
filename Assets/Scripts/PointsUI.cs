using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    float points = 0; 
    TextMeshProUGUI pointText; 
    private void Start()
    {
        Coin.OnCollected += UpdatePoints;
        pointText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdatePoints(float addedpoints)
    {
        points += addedpoints;
        pointText.text = "Points: " + points; 
    }

    private void OnDestroy()
    {
        Coin.OnCollected -= UpdatePoints; 
    }
}
