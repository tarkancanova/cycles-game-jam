using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animation")]

    
    private Animator _characterAnimator;

    public Animator CharacterAnimator  //dýþardan eriþebilmek için getter setterlar kullandým
    {
        get { return _characterAnimator; }
        set { _characterAnimator = value; }
    }
    

    [Header("Player Rigidbody")]

    [SerializeField] private Rigidbody _rb;


    [Header("Movement Area")]

    [SerializeField] private float _characterForwardSpeed;

    public float CharacterForwardSpeed    //dýþardan eriþebilmek için getter setterlar kullandým
    {
        get { return _characterForwardSpeed; }
        set { _characterForwardSpeed = value; }
    }

    [SerializeField] private float _characterHorizontalSpeed;
    private Vector3 _movement = new Vector3();


    [Header("Rotation Area")]

    [SerializeField] private float _maxRotationAngle;
    [SerializeField] private float _rotationLerpSpeed;
    private Quaternion _targetRotation;


    private void Start()
    {
        _characterAnimator = GetComponent<Animator>();
       
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.LeftShift)))
        {
            
            _characterAnimator.SetTrigger("slideTrigger");
        }

       
            
    }

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
