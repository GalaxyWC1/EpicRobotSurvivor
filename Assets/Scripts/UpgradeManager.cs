using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject upgradeSelectionUI;
    [SerializeField] GameObject upgradePrefab;
    [SerializeField] Transform upgradePositionOne;
    [SerializeField] Transform upgradePositionTwo;
    [SerializeField] Transform upgradePositionThree;
    [SerializeField] List<Upgrades> deck;

    GameObject upgradeOne, upgradeTwo, upgradeThree;

    List<Upgrades> alreadySelectedUpgrades = new List<Upgrades>();

    public static UpgradeManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RandomizeUpgrades();
    }

    void RandomizeUpgrades()
    {
        if (upgradeOne != null) Destroy(upgradeOne);
        if (upgradeTwo != null) Destroy(upgradeTwo);
        if (upgradeThree != null) Destroy(upgradeThree);

        List<Upgrades> randomizedUpgrades = new List<Upgrades>();

        List<Upgrades> availableUpgrades = new List<Upgrades>(deck);
        availableUpgrades.RemoveAll(upgrade => upgrade.isUnique && alreadySelectedUpgrades.Contains(upgrade));

        if(availableUpgrades.Count < 3)
        {
            Debug.Log("Not enough available cards");
            return;
        }

        while(randomizedUpgrades.Count < 3)
        {
            Upgrades randomCard = availableUpgrades[Random.Range(0, availableUpgrades.Count)];
            if(!randomizedUpgrades.Contains(randomCard))
            {
                randomizedUpgrades.Add(randomCard);
            }
        }

        upgradeOne = InstantiateUpgrade(randomizedUpgrades[0], upgradePositionOne);
        upgradeOne = InstantiateUpgrade(randomizedUpgrades[1], upgradePositionTwo);
        upgradeOne = InstantiateUpgrade(randomizedUpgrades[2], upgradePositionThree);

        ShowUpgradeSelection();
    }

    GameObject InstantiateUpgrade(Upgrades upgrades, Transform position)
    {
        GameObject upgradeGO = Instantiate(upgradePrefab, position.position, Quaternion.identity, position);
        Upgrade upgrade = upgradeGO.GetComponent<Upgrade>();
        upgrade.Setup(upgrades);
        return upgradeGO;
    }

    public void SelectUpgrade(Upgrades selectedUpgrade)
    {
        if(alreadySelectedUpgrades.Contains(selectedUpgrade))
        {
            alreadySelectedUpgrades.Add(selectedUpgrade);
        }

        HideUpgradeSelection();
        Time.timeScale = 1;
    }

    public void ShowUpgradeSelection()
    {
        upgradeSelectionUI.SetActive(true);
    }

    public void HideUpgradeSelection()
    {
        upgradeSelectionUI.SetActive(false);
    }
}
