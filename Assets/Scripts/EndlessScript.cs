using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EndlessScript : MonoBehaviour
{
    public GameObject[] platforms;
    [SerializeField] private GameObject player;

    public List<GameObject> createdTiles;


    Vector3 pos = new(0, 0, 0);

    void Start()
    {


        float waitTime = 0.4f;
        InvokeRepeating("CreatePlatform", 0, waitTime);

    }

    private void CreatePlatform()
    {

        int platformNumber = Random.Range(0, platforms.Length);
        GameObject PlatformCreator = Instantiate(platforms[platformNumber], pos, Quaternion.identity) as GameObject;
        pos.z += 100f;
        //createdTiles.Add(PlatformCreator);



    }

    //void Update()
    //{
    //    foreach (GameObject createdTile in createdTiles)
    //    {
    //        if (createdTile != null && player.transform.position.z >= plane.transform.position.z + 15)
    //            if (createdTile.name == "Plane(Clone)")
    //              Destroy(createdTile, 3f);
    //    }
    //}


}

 