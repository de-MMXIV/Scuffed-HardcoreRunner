using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    /// <summary>
    /// Programmed by Florentin Lüdeking
    /// </summary>
    private int identifier = 0;
    private float time;
    private Vector3 startVector3;
    /// <summary>
    /// Executes TrapType
    /// Sets the startVector3 as the current position of the object
    /// </summary>
    void Start()
    {
        TrapType();
        startVector3 = transform.position;
    }
    /// <summary>
    /// Executes Trap Movement 
    /// </summary>
    void Update()
    {
        TrapMovement(identifier);
    }
    /// <summary>
    /// looks at the identifier and executes the set movement
    /// </summary>
    /// <param name="_identifier">the current kind of trap the script is part of </param>
    private void TrapMovement(int _identifier)
    {
        switch (_identifier)
        {
            case 1:
                transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
                break;
            case 2:
                transform.Rotate(new Vector3(100, 0, 0) * Time.deltaTime);
                break;
            case 3:
                transform.Rotate(new Vector3(0, -100, 0) * Time.deltaTime);
                break;
        }
    }
    /// <summary>
    /// looks at the name of the current object and sets the identifier to a number
    /// </summary>
    private void TrapType()
    {
        switch (this.gameObject.name)
        {
            case "Rotation Trap":
                identifier = 1;
                break;
            case "Rotator":
                identifier = 2;
                break;
            case "Rotation Trap2":
                identifier = 3;
                break;
        }
    }
}
