using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {

	public Rigidbody ball;
	public Transform camera;

	public float putStrength;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			PushBall (putStrength);
		}
	}

	public void PushBall(float force)
	{
		ball.AddForce ( (camera.forward + camera.up) * force, ForceMode.Impulse);
	}
}
