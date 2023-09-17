using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    GameObject playerObj;
    Player player;
    Transform playerTransform;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerTransform = playerObj.transform;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {

        //横方向だけ追従
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }

}