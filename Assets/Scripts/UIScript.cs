using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject moneyObject;
    private TextMeshProUGUI moneyText;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyText = moneyObject.GetComponent<TextMeshProUGUI>();
        MoneyManager.Instance.OnMoneyChanged += UpdateUI;
        UpdateUI(MoneyManager.Instance.money);
    }

    // Update is called once per frame
    void UpdateUI(int newMoney)
    {
        moneyText.text = newMoney.ToString();
    }

    void OnDestroy()
    {
        MoneyManager.Instance.OnMoneyChanged -= UpdateUI;
    }


}
