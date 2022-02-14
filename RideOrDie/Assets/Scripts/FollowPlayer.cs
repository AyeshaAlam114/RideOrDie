using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraOffset;

    void LateUpdate()
    {
        if (!(Input.GetKeyDown(KeyCode.Space)))
            CameraFlow();
        else
            Invoke(nameof(CameraFlow), 2f);      
    }

    void CameraFlow()
    {
        transform.position = player.transform.position + cameraOffset;
        transform.position = new Vector3(0, cameraOffset.y, transform.position.z);
    }
}
