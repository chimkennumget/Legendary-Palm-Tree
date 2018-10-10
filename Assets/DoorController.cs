using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	// the door from this object
	public GameObject Room1Door;
	// the door copied and rotated/moved to be the opened door
	public GameObject DoorOpen;
	// this will be a copy of the original door so that we have some numbers to work with.
	private GameObject DoorClosed;
	// this controls if the door is opened or closed.
	public bool isOpened = false;

	// this is the movement rate (if movemnt is applied to the door)
	public float moveSpeed = 3;
	// this is the rotation rate (if rotation is applied to the door)
	public float rotationSpeed = 90;

	void Start() {
		// copy the door to keep its position
		DoorClosed = Instantiate(Room1Door, Room1Door.transform.position, Room1Door.transform.rotation);
		// hide both the open and closed door
		DoorClosed.SetActive(false);
		DoorOpen.SetActive(false);
	}

	void Update(){
		// every frame, move the door towards the Open/Closed door
		var target = isOpened ? DoorOpen : DoorClosed;
		// these actually do the moving/rotating
		Room1Door.transform.position = Vector3.MoveTowards(Room1Door.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
		Room1Door.transform.rotation = Quaternion.RotateTowards(Room1Door.transform.rotation, target.transform.rotation, rotationSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider cube)
	{
		// whenever anything enters the trigger, open the door
		isOpened = true;
	}

	void OnTriggerExit(Collider cube){
		// whenever anything exits the trigger, close the door.
		isOpened = false;
	}
}
