using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameObject moneyObject;
    public GameObject healthObject;
    private TextMeshProUGUI moneyText;
    private TextMeshProUGUI healthText;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText = moneyObject.GetComponent<TextMeshProUGUI>();
        healthText = healthObject.GetComponent<TextMeshProUGUI>();

        MoneyManager.Instance.OnMoneyChanged += UpdateUI;
        WaveManager.Instance.OnHealthChanged += UpdateUI;
        
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        moneyText.text = "Money : " + MoneyManager.Instance.money.ToString();
        healthText.text = "HP : " + WaveManager.Instance.healthCore.ToString();
        print(healthText.text);

    }

    void OnDestroy()
    {
        MoneyManager.Instance.OnMoneyChanged -= UpdateUI;
    }


}
