using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] SpriteRenderer upgradeImageRenderer;
    [SerializeField] TextMeshPro upgradeTextRenderer;
    private Upgrades upgradeInfo;
    public void Setup(Upgrades upgrade)
    {
        upgradeInfo = upgrade;
        upgradeImageRenderer.sprite = upgrade.UpgradeImage;
        upgradeTextRenderer.text = upgrade.upgradeText;
    }

    private void OnMouseDown()
    {
        Debug.Log("select");
        UpgradeManager.Instance.SelectUpgrade(upgradeInfo);
    }


}
