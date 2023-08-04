using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitObstacle : MonoBehaviour
{

    private bool _isGameDone = false;
    public bool IsGameDone
    {
        get { return _isGameDone; }
        set { _isGameDone = value; }
    }


    private PlayerMovement _playerMovementScript;
    

    private void Start()
    {
        _playerMovementScript = GetComponent<PlayerMovement>();
       
    }

    
    
    
   
    private void OnCollisionEnter(Collision collision)
    {

       
        if (collision.gameObject.CompareTag("UpObstacle"))
        {

            _playerMovementScript.isGameEnd = true;
            _playerMovementScript.CharacterForwardSpeed = 0f;
            _playerMovementScript.CharacterAnimator.SetTrigger("IsDeathWithUpObstacle");
            IsGameDone = true;
            

            UIManager uiManager = FindObjectOfType<UIManager>();
            if (uiManager != null)
            {
                uiManager.OnGameDone();
            }
        }
    }
}
