using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController2 : MonoBehaviour
{
public Transform CamTransform;
public CharacterController CC;
public float MoveSpeed;
public float Gravity = -9.8f;
public float verticalSpeed;
private float hP = 10;
private float hP2 = 10;

private void Start()
{
Cursor.lockState = CursorLockMode.Locked;
}

private void Update()
{
Vector3 movement = Vector3.zero;

// X/Z movement
float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

if (CC.isGrounded)
{
verticalSpeed = 0f;

}
verticalSpeed += (Gravity * Time.deltaTime);
movement += (transform.up * verticalSpeed * Time.deltaTime);

CC.Move(movement);
}

private void FixedUpdate()
{


if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
        
			    if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
			    {
                   
		    		    Debug.Log(hit.collider.gameObject.name);
					if(hit.collider.gameObject.name == "target1")
                    {
						hP--;
						if(hP==0)
						{
							Destroy(hit.transform.gameObject);
						}
		    	    }
					if(hit.collider.gameObject.name == "target2")
                    {
						hP2--;
						if(hP2==0)
						{
							Destroy(hit.transform.gameObject);
						}
		    	    }

                }
		}
	}
}