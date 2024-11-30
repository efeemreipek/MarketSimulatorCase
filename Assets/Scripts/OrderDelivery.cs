using UnityEngine;

public class OrderDelivery : MonoBehaviour
{
    [SerializeField] private InputValues inputValues;
    [SerializeField] private GameObject boxPrefab;

    private void Update()
    {
        if(inputValues.ButtonOne)
        {
            inputValues.ButtonOne = false;
            OrderProductDelivery("Soda", 12, 0);
        }
        if(inputValues.ButtonTwo)
        {
            inputValues.ButtonTwo = false;
            OrderProductDelivery("Sauce", 12, 1);
        }
        if(inputValues.ButtonThree)
        {
            inputValues.ButtonThree = false;
            OrderProductDelivery("Chocolate", 12, 2);
        }
    }

    private void OrderProductDelivery(string name, int amount, int productIndex)
    {
        var box = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        box.GetComponent<Box>().InitializeBox(new Product(name, amount), productIndex);
    }
}
