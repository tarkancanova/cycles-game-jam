using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitObstacle : MonoBehaviour
{


    private PlayerMovement playerMovementScript;

    private void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    
    
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpObstacle"))
        {
            playerMovementScript.CharacterForwardSpeed = 0f;
            playerMovementScript.CharacterAnimator.SetTrigger("IsDeathWithUpObstacle");
            
        }
    }
}
