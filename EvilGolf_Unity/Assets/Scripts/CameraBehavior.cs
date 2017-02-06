using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

	public GameObject ball;

	public float zoom;
	public float minZoom;
	public float maxZoom;

	private float lastMouseXPosition;
	public float mouseSensitivity;

	public Vector2 ballPositionInScreen;

	public float yaw; // mouse Y
	public float yawMin;
	public float yawMax;

	public float pitch; // mouse X


	// Use this for initialization
	void Start () 
	{
		lastMouseXPosition = Input.mousePosition.x;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		// rotation pitch
		float mouseXDelta = Input.mousePosition.x - lastMouseXPosition;
		pitch += (mouseXDelta * mouseSensitivity);
		lastMouseXPosition = Input.mousePosition.x;

		// rotation yaw
		float yawRatio = 1-(Input.mousePosition.y / Screen.height);
		yaw = (yawMin + yawRatio * (yawMax - yawMin));

		Rotate (pitch, yaw);

		// zoom
		zoom -= Input.mouseScrollDelta.y;
		zoom = (zoom < minZoom) ? minZoom : ((zoom > maxZoom) ? maxZoom : zoom);
		Translate (zoom);

	}

	public void Rotate(float inputPitch, float inputYaw)
	{
		this.transform.rotation = Quaternion.identity;
		this.transform.RotateAround (ball.transform.position, this.transform.up, inputPitch);
		this.transform.RotateAround (ball.transform.position, this.transform.right, inputYaw);
	}

	public void Translate(float distance)
	{
		Vector3 cameraBallVec = (this.transform.forward + ballPositionInScreen.x * this.transform.right + ballPositionInScreen.y * this.transform.up).normalized;
		this.transform.position = ball.transform.position - distance * cameraBallVec;
	}
}
