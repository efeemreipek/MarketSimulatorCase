using UnityEngine;

public class CashRegisterScreen : MonoBehaviour
{
    private CashRegister cashRegister;

    public CashRegister CashRegister => cashRegister;

    private void Awake()
    {
        cashRegister = GetComponentInParent<CashRegister>();
    }
}
