using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Player Rigidbody")]

    [SerializeField] private Rigidbody _rb;


    [Header("Movement Area")]

    [SerializeField] private float _characterForwardSpeed;
    [SerializeField] private float _characterHorizontalSpeed;
    
    private Vector3 _movement = new Vector3();


    [Header("Rotation Area")]

    [SerializeField] private float _maxRotationAngle;
    [SerializeField] private float _rotationLerpSpeed;
    private Quaternion _targetRotation;


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //movement code area
        _movement.z = _characterForwardSpeed;
        _movement.x = moveHorizontal * _characterHorizontalSpeed;
        _movement.y = _rb.velocity.y;
        _rb.velocity = _movement;

        // Rotation code area
        float rotationAmount = moveHorizontal * _maxRotationAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        _targetRotation = Quaternion.Lerp(_targetRotation, targetRotation, _rotationLerpSpeed * Time.deltaTime);
        transform.rotation = _targetRotation;
    }
}
