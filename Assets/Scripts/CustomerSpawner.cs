using Cysharp.Threading.Tasks;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;

    private void Start()
    {
        SpawnCustomers().Forget();
    }

    private async UniTaskVoid SpawnCustomers()
    {
        await UniTask.Delay(10000);

        while(true)
        {
            Instantiate(customerPrefab, transform.position, Quaternion.identity);
            await UniTask.Delay(10000);
        }
    }
}
