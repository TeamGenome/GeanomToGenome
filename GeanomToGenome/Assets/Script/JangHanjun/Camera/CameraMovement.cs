using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 newPosition;
    private Camera cam;
    [Header("카메라 움직임 관련")]
    [SerializeField] private float moveSpeed;
    
    [SerializeField] private float xMin, xMax, zMin, zMax;    

    [Header("카메라 줌 관련")]
    [SerializeField] private float zoomSpeed;
    private float fov;
    [SerializeField] private float fovMin, fovMax;

    private void Start()
    {
        cam = Camera.main;
        newPosition = transform.position;
    }

    void Update() 
    {
        if(Input.GetMouseButton(0))
            MoveCamera();

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    private void MoveCamera()
    {
        transform.position -= new Vector3(Input.GetAxis("Mouse X") * moveSpeed * Time.deltaTime, 0f, 
                                        Input.GetAxis("Mouse Y") * moveSpeed * Time.deltaTime);

        newPosition.x = Mathf.Clamp(transform.position.x, xMin, zMax);
        newPosition.z = Mathf.Clamp(transform.position.z, zMin, zMax);

        transform.position = newPosition;
    }

    private void ZoomCamera(float input)
    {
        cam.fieldOfView -= input * zoomSpeed;
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, fovMin, fovMax);
    }
}
