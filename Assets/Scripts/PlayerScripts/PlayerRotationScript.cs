using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationScript : MonoBehaviour
{


    [SerializeField] float rotationSpeed;
    float inputRotation;

    // Use this for initialization
    void Start ()
    {
        rotationSpeed = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("RightHorizontal") != 0 || Input.GetAxis("RightVertical") != 0)
        {
            inputRotation = Mathf.Atan2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical")) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, -inputRotation)), rotationSpeed * Time.deltaTime);//Quaternion.Euler(0, 0, inputRotation);
        }

    }
}
