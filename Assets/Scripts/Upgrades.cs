using UnityEngine;

[CreateAssetMenu(fileName = "new Upgrade", menuName = "Upgrades")]
public class Upgrades : ScriptableObject
{
    public Sprite UpgradeImage;

    public string upgradeText;
    public UpgradeEffect effectType;
    public float effectValue;
    public bool isUnique;
}

public enum UpgradeEffect
{
    DamageIncrease,
    HealthIncrease,
    AttackSpeedIncrease,
    CooldownDecrease,
    GiveField,

}
