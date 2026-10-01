using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{

    public Stats stats;

    public Image HealthBar;
    public Image ManaBar;
    public Image XpBar;

    public TextMeshProUGUI Score;
    public TextMeshProUGUI Timer;

    private float time;

    // Update is called once per frame
    void Update()
    {
        if(Timer)
        {
            time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }    

        if(Score)
        {
            int score = stats.score;
            Score.text = string.Format("Score: {0}", score);
        }

        if(XpBar)
        {
            XpBar.fillAmount = stats.xp / stats.maxXp;
        }

        if(HealthBar || ManaBar)
        {
            HealthBar.fillAmount = stats.currentHealth / stats.maxHealth;
            ManaBar.fillAmount = stats.currentMana / stats.maxMana;
        }
    }
}
