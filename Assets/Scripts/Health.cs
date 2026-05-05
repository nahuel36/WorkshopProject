using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField, ReadOnlyInInspector] Slider _healthBar;
    [SerializeField] GameObject _youLoosePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.onDamage += Enemy_OnDamage;
        _healthBar = GetComponent<Slider>();
    }

    private void Enemy_OnDamage(float damage)
    {
        _healthBar.value -= damage / (float)100;
        if (_healthBar.value <= 0)
        {
            _youLoosePanel.SetActive(true);
            Time.timeScale = 0; // Stop the game
        }
    }


}
