using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private NavMeshAgent nmAgent;

    private CashRegister cashRegister;
    private Transform exitPoint;
    private Shelf targetShelf;
    private int amountToBuy;
    private float amountToPay;

    private bool isTargetReached;
    private bool isTransactionCompleted = false;

    public float AmountToPay => amountToPay;
    public bool IsTransactionCompleted { get => isTransactionCompleted; set => isTransactionCompleted = value; }

    private void Awake()
    {
        nmAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        CustomerBehaviour().Forget();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, nmAgent.destination) < 0.25f)
        {
            isTargetReached = true;
        }
        else
        {
            isTargetReached = false;
        }
    }

    private async UniTaskVoid CustomerBehaviour()
    {
        var shelves = FindObjectsByType<Shelf>(FindObjectsSortMode.None);
        targetShelf = shelves[Random.Range(0, shelves.Length)];

        cashRegister = FindFirstObjectByType<CashRegister>();
        exitPoint = GameObject.FindGameObjectWithTag("ExitPoint").transform;

        nmAgent.SetDestination(targetShelf.StopPoint.position);
        await UniTask.WaitUntil(() => isTargetReached);

        amountToBuy = Mathf.Min(Random.Range(1, 3), targetShelf.ProductAmount);
        await UniTask.Delay(2000);
        amountToPay = amountToBuy * targetShelf.ProductPrice;
        targetShelf.RemoveFromShelf(amountToBuy);

        nmAgent.SetDestination(cashRegister.StopPoint.position);
        await UniTask.WaitUntil(() => isTargetReached);
        cashRegister.WaitingCustomer = this;

        await UniTask.WaitUntil(() => isTransactionCompleted);

        nmAgent.SetDestination(exitPoint.position);
        await UniTask.WaitUntil(() => isTargetReached);

        Destroy(gameObject);
    }

    private async UniTask ProcessTransaction()
    {
        await UniTask.WaitUntil(() => isTransactionCompleted);
        Debug.Log("Transaction complete!");
    }

}
