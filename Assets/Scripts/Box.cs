using UnityEngine;

public class Box : MonoBehaviour
{
    private Product product;
    private int productIndex;
    private int initialProductAmount;
    private int productAmountLeft;
    private bool isEmpty = false;

    public int ProductIndex => productIndex;
    public bool IsEmpty => isEmpty;

    public void InitializeBox(Product product, int productIndex)
    {
        this.product = product;
        this.productIndex = productIndex;
        initialProductAmount = this.product.InitialAmount;
        productAmountLeft = initialProductAmount;
    }

    public void DecreaseProductAmountLeft()
    {
        productAmountLeft = Mathf.Max(productAmountLeft - 1, 0);
        if(productAmountLeft <= 0)
        {
            isEmpty = true;
        }
    }
}
