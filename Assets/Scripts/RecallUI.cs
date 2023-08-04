using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class RecallUI : MonoBehaviour
{

    [SerializeField] private Image imageCooldown;
    [SerializeField] private TMP_Text textCooldown;

    private bool isCooldown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;

    void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            UseRecall();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }

    }

    public void UseRecall()
    {
        if (isCooldown)
        {
            // recall has used
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;
        }
        else 
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }
}
