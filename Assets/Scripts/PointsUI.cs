using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [ReadOnlyInInspector][SerializeField] int _points = 0; 
    TextMeshProUGUI _pointText; 
    private void Start()
    {
        Coin.onCollected += UpdatePoints;
        _pointText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdatePoints(int addedpoints)
    {
        _points += addedpoints;
        _pointText.text = "Points: " + _points; 
    }

    private void OnDestroy()
    {
        Coin.onCollected -= UpdatePoints; 
    }
}
