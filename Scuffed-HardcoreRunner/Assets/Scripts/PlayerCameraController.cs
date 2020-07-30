using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float RotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMovement();
    }

    public void CameraMovement()
    {
        //Mouse Movement Left and Right
        mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        //Mouse Movement up and Down
        mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        //Prevent the Camera of flipping around and make sure the Camera follows the Player
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

}
