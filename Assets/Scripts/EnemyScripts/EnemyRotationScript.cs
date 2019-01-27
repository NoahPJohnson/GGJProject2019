using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotationScript : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    float guideRotation;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        guideRotation = Mathf.Atan2(transform.parent.GetComponent<EnemyMovementScript>().GetGuideVector().x, transform.parent.GetComponent<EnemyMovementScript>().GetGuideVector().y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,-guideRotation), Time.deltaTime * turnSpeed);
    }

    public void SetTurnSpeed(float newTurnSpeed)
    {
        turnSpeed = newTurnSpeed;
    }
}
