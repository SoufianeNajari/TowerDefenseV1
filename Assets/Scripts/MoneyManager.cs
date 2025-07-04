using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    //Instance pour accès global
    public static MoneyManager Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    //Event
    public event Action OnMoneyChanged;


    public int money { get; private set; } = 10;

    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        OnMoneyChanged?.Invoke();
    }

    public bool UseMoney(int moneyToUse)
    {
        if (money >= moneyToUse)
        {
            money -= moneyToUse;
            OnMoneyChanged?.Invoke();
            return true;
        }
        return false;
    }

}
