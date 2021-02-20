using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float sensitivity;
    public Transform mainCamera;

    // Start is called before the first frame update
    void Start()
    {
    }
    void FixedUpdate()
    {
        player.transform.rotation = mainCamera.rotation;
        player.transform.rotation = Quaternion.Euler(new Vector3(0, mainCamera.eulerAngles.y, mainCamera.eulerAngles.z));
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
