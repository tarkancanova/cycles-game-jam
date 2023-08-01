using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    [SerializeField] public float maxDuration;
    [SerializeField] private float saveInterval;
    [SerializeField] float recallSpeed;
    [SerializeField] private Animator playerAnimator;

    [SerializeField] List<Vector3> positions;

    private bool recalling;
    private float saveStatsTimer;
    private float maxStatsStored;

    private void Start()
    {
        maxStatsStored = maxDuration / saveInterval;
    }

    private void Update()
    {
        PlayerRecall();
    }

    private void PlayerRecall()
    {
        if (!recalling)
        {
            if (Input.GetKeyDown(KeyCode.E) && positions.Count > 0)
            {
                playerAnimator.SetBool("isRecalling", true);
                recalling = true;
            }

            if (saveStatsTimer > 0)
            {
                saveStatsTimer -= Time.deltaTime;
            }
            else
            {
                StoreStats();
            }
        }
        else
        {
            if (positions.Count > 0)
            {
                transform.position = Vector3.Lerp(transform.position, positions[0], recallSpeed * Time.deltaTime);

                float dist = Vector3.Distance(transform.position, positions[0]);
                if (dist < 0.25f)
                {
                    SetStats();
                }
            }
            else
            {

                playerAnimator.SetBool("isRecalling", false);
                recalling = false;
            }
        }
    }

    private void StoreStats()
    {
        saveStatsTimer = saveInterval;

        positions.Insert(0, transform.position);

        if (positions.Count > maxStatsStored)
        {
            positions.RemoveAt(positions.Count - 1);
        }

    }

    private void SetStats()
    {
        transform.position = positions[0];

        positions.RemoveAt(0);
    }

}