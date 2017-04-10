using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis(Controller.RightStickX);
        var y = Input.GetAxis(Controller.RightStickY);

        transform.Rotate(y, x, 0);
        // Right Stick is mapped to HorizontalR and VerticalR
    }
}
