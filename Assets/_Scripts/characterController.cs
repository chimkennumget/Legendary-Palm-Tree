using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {

    public float speed = 10.0f;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public bool isCursor;
    // Inital Point counter score
    public int points = 0;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 6.0f, 0.0f);
	}
	
    // jump function
    void OnCollisionStay()
    {
        isGrounded = true;
    }

	// Update is called once per frame
	void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


	}

    void OnTriggerEvent(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }



    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score : " + points);

        if (points >= 30)
        {
            GUI.Label(new Rect(100, 100, 100, 20), "YOU WIN");
        }
    }
}
