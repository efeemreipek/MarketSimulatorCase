using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputValues inputValues;
    [SerializeField] private ProductList productList;
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private Transform itemHolderTransform;
    [SerializeField] private GameObject priceChangePanelGO;

    private bool isHoldingItem = false;
    private Box currentBox;
    private Transform currentItem;


    private void Update()
    {
        if(inputValues.LeftClick)
        {
            inputValues.LeftClick = false;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit, interactionRange))
            {
                if(!isHoldingItem)
                {
                    if(hit.collider.TryGetComponent(out Box box))
                    {
                        isHoldingItem = true;
                        currentBox = box;
                        currentItem = hit.transform;
                        currentItem.position = itemHolderTransform.position;
                        currentItem.SetParent(itemHolderTransform);
                    }
                }
                else
                {
                    if(hit.collider.TryGetComponent(out Shelf shelf) && !currentBox.IsEmpty)
                    {
                        var productGO = Instantiate(productList.products[currentBox.ProductIndex], hit.point, Quaternion.identity);
                        productGO.transform.SetParent(shelf.transform);
                        shelf.Products.Add(productGO);
                        currentBox.DecreaseProductAmountLeft();
                    }
                    else
                    {
                        isHoldingItem = false;
                        currentBox = null;
                        currentItem.position = hit.point;
                        currentItem.rotation = Quaternion.identity;
                        itemHolderTransform.DetachChildren();
                        currentItem = null;
                    }
                }
            }
        }

        if(inputValues.RightClick)
        {
            inputValues.RightClick = false;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f));
            if(Physics.Raycast(ray, out RaycastHit hit, interactionRange))
            {
                if(hit.collider.TryGetComponent(out Shelf shelf) && !shelf.IsShelfEmpty)
                {
                    UIManager.Instance.OpenPriceChangePanel(shelf);
                }

                if(hit.collider.TryGetComponent(out CashRegisterScreen screen))
                {
                    UIManager.Instance.OpenCashRegisterPanel(screen);
                }
            }
        }
    }
}
