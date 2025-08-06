using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Slider healthBar;
    [SerializeField] GameObject youLoosePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy.OnDamage += Enemy_OnDamage;
        healthBar = GetComponent<Slider>();
    }

    private void Enemy_OnDamage(float damage)
    {
        healthBar.value -= damage / (float)100;
        if (healthBar.value <= 0)
        {
            youLoosePanel.SetActive(true);
            Time.timeScale = 0; // Stop the game
        }
    }


}
