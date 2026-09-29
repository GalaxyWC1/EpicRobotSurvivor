using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{

    public Stats stats;

    public Image HealthBar;
    public Image ManaBar;

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = stats.currentHealth / stats.maxHealth;
        ManaBar.fillAmount = stats.currentMana / stats.maxMana;
    }
}
