using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private InputValues inputValues;
    [SerializeField] private float sensitivity;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;

    private float pitch;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = transform.parent;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        float horizontalRotation = inputValues.Look.x * sensitivity * Time.deltaTime;
        playerTransform.Rotate(Vector3.up, horizontalRotation);

        pitch -= inputValues.Look.y * sensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minAngle, maxAngle);

        transform.localEulerAngles = new Vector3(pitch, transform.localEulerAngles.y, 0f);
    }

}
