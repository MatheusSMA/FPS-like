using UnityEngine;


public class GunSway : MonoBehaviour
{
    [Header("Sway Pos")]
    [SerializeField] private float amount = .02f;
    [SerializeField] private float maxAmount = .06f, smoothAmount = 6f;

    [Header("Rotation")]
    [SerializeField] private float rotationAmount = 4f;
    [SerializeField] private float maxRotationAmount = 5f, smoothRotation = 12f;
    public bool rotationX = true, rotationY = true, rotationZ = true;

    private Vector3 inicialPosition;
    private Quaternion inicialRotation;

    private float _inputX;
    private float _inputY;

    private void Start()
    {
        inicialPosition = transform.localPosition;
        inicialRotation = transform.localRotation;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        CalculateSway();

        MoveSway();
        TiltSway();
    }

    private void CalculateSway()
    {
        _inputX = -Input.GetAxis("Mouse X");
        _inputY = -Input.GetAxis("Mouse Y");
    }
    private void MoveSway()
    {
        float moveX = Mathf.Clamp(_inputX * amount, -maxAmount, maxAmount);
        float moveY = Mathf.Clamp(_inputY * amount, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(moveX, moveY, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + inicialPosition, Time.deltaTime * smoothAmount);
    }
    private void TiltSway()
    {
        float tiltY = Mathf.Clamp(_inputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float tiltX = Mathf.Clamp(_inputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

        Quaternion finalRotation = Quaternion.Euler(new Vector3(
            rotationX ? -tiltX : 0f,
            rotationY ? tiltY : 0f,
            rotationZ ? tiltY : 0f
        ));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * inicialRotation, Time.deltaTime * smoothRotation);
    }


}