using UnityEngine;

public class CashRegister : MonoBehaviour
{
    private Customer waitingCustomer;

    public Transform StopPoint;
    public Customer WaitingCustomer { get => waitingCustomer; set => waitingCustomer = value; }

}
