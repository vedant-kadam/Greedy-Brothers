using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform PlayerTransform;

    private void Update()
    {
        Vector3 tempPos = PlayerTransform.position;
        tempPos.x = Mathf.Clamp(tempPos.x, 0f, 18f);
        tempPos.y = Mathf.Clamp(tempPos.y, 6.9f, 56f);

        transform.position = Vector3.Lerp(transform.position, new Vector3(tempPos.x, tempPos.y, transform.position.z), 2 * Time.deltaTime);
    }
}
