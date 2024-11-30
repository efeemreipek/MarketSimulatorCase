using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductList", menuName = "Scriptable Objects/ProductList")]
public class ProductList : ScriptableObject
{
    public List<GameObject> products = new List<GameObject>();
}
