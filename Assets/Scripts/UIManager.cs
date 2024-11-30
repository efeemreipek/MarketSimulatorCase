using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject priceChangePanelGO;
    [SerializeField] private TMP_InputField priceChangeInputField;
    [SerializeField] private Button priceChangeButton;
    [SerializeField] private GameObject cashRegisterPanelGO;
    [SerializeField] private TextMeshProUGUI amountToPayText;
    [SerializeField] private TMP_InputField cashRegisterInputField;
    [SerializeField] private Button cashRegisterButton;

    private Shelf currentShelf;
    private Customer currentCustomer;

    public void OpenPriceChangePanel(Shelf shelf)
    {
        currentShelf = shelf;

        priceChangePanelGO.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void OpenCashRegisterPanel(CashRegisterScreen screen)
    {
        currentCustomer = screen.CashRegister.WaitingCustomer;

        cashRegisterPanelGO.SetActive(true);
        amountToPayText.text = currentCustomer.AmountToPay.ToString();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ApplyPriceChange()
    {
        currentShelf.ApplyPriceChange(float.Parse(priceChangeInputField.text));
        priceChangePanelGO.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        currentShelf = null;
    }

    public void ApplyCheckout()
    {
        if(cashRegisterInputField.text == amountToPayText.text)
        {
            currentCustomer.IsTransactionCompleted = true;

            cashRegisterPanelGO.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            currentCustomer = null;
        }
    }
}
