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
    public  bool isGameEnd;
    

    [Header("Player Rigidbody")]

    [SerializeField] private Rigidbody _rb;


    [Header("Movement Area")]

    [SerializeField] private float _characterForwardSpeed = 0;

    public float CharacterForwardSpeed    //dýþardan eriþebilmek için getter setterlar kullandým
    {
        get { return _characterForwardSpeed; }
        set { _characterForwardSpeed = value; }
    }
    [SerializeField] private float _characterHorizontalSpeed;
    private Vector3 _movement = new Vector3();
    [SerializeField] private float _characterJumpPower;


    [Header("Rotation Area")]

    [SerializeField] private float _maxRotationAngle;
    [SerializeField] private float _rotationLerpSpeed;
    private Quaternion _targetRotation;


    private void Start()
    {
        isGameEnd = false;
        _characterAnimator = GetComponent<Animator>();
        Invoke("InvokeCharacterForwardSpeed", .2f);
    }

    private void Update()
    {
        
       
        if(!isGameEnd) 
        {
            if ((Input.GetKeyDown(KeyCode.LeftShift)))
            {
                _characterAnimator.SetTrigger("slideTrigger");
            }

        }
       

       
    }

    private void FixedUpdate()
    {
        if (!isGameEnd)
        {
            AnimatorStateInfo stateInfo = _characterAnimator.GetCurrentAnimatorStateInfo(0);
            float moveHorizontal = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("girdi");
                _characterAnimator.SetBool("Jump", true);
                _movement.y = _characterJumpPower;
            }





            if (stateInfo.IsName("Jump"))
            {
                _movement.y = _rb.velocity.y;
                _characterAnimator.SetBool("Jump", false);

            }



            if (stateInfo.IsName("Slide") || stateInfo.IsName("Recall"))
            {
                _movement.x = moveHorizontal * _characterHorizontalSpeed * 0;
                _movement.z = _characterForwardSpeed - 1;

            }
            else
            {
                Debug.Log("kaymýyor");
                _movement.x = moveHorizontal * _characterHorizontalSpeed;
                _movement.z = _characterForwardSpeed;

                // Rotation code area
                float rotationAmount = moveHorizontal * _maxRotationAngle;
                Quaternion targetRotation = Quaternion.Euler(0f, rotationAmount, 0f);
                _targetRotation = Quaternion.Lerp(_targetRotation, targetRotation, _rotationLerpSpeed * Time.deltaTime);
                transform.rotation = _targetRotation;
            }

            //movement code area


            _rb.velocity = _movement;
        }
        
        

        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Tile"))
            Destroy(other.gameObject);
    }

    public void InvokeCharacterForwardSpeed()
    {
        _characterForwardSpeed = 8;
    }
}
