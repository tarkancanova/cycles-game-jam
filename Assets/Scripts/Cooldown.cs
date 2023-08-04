using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Cooldown 
{
    [SerializeField] private float cooldownTime;
    private float _nextRecallTime;

    public bool IsCoolingDown => Time.time < _nextRecallTime;
    public void StartCooldown() => _nextRecallTime = Time.time + cooldownTime;
}
