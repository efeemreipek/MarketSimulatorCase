using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField] private TextMeshPro priceText;

    private float productPrice;

    public List<GameObject> Products = new List<GameObject>();
    public Transform StopPoint;

    public bool IsShelfEmpty => Products.Count == 0;
    public int ProductAmount => Products.Count;
    public float ProductPrice => productPrice;

    public void ApplyPriceChange(float newPrice)
    {
        productPrice = newPrice;
        priceText.text = $"Price: {newPrice.ToString()}";
    }

    public void RemoveFromShelf(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject last = Products[Products.Count - 1];
            Products.Remove(last);
            Destroy(last);
        }
    }
}
