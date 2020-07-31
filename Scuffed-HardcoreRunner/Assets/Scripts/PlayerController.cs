using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEditor;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private float speed = 6;

    public Vector3 startPos;

    public bool isGrounded;
    public Vector3 jump;
    public float JumpForce = 4.0f;

    public GameObject PlayerCamera;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        startPos = transform.position;
        if (this.isLocalPlayer)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerCamera.SetActive(true);
            rb = GetComponent<Rigidbody>();
            jump = new Vector3(0, 4.0f, 0);
        }
        else
        {
            PlayerCamera.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    /// <summary>
    /// Basic Player Movement
    /// </summary>
    public void PlayerMovement()
    {
        var hor = Input.GetAxis("Horizontal");
        var ver = Input.GetAxis("Vertical");

        if (this.isLocalPlayer)
        {
            Vector3 playerMovement = new Vector3(hor, 0, ver) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            //Basic Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(jump * JumpForce, ForceMode.Impulse);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
