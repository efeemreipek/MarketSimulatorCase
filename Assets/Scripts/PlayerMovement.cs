using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputValues inputValues;
    [SerializeField] private float speed = 5f;

    private Rigidbody rb;
    private Transform cameraTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Vector3 move = cameraTransform.forward * inputValues.Move.y + cameraTransform.right * inputValues.Move.x;
        move.y = 0f;
        rb.AddForce(move.normalized * speed, ForceMode.VelocityChange);
    }

}
