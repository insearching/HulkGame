using UnityEngine;
using System.Collections;

public class Hulk : MonoBehaviour {

	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float maxSpeed = 10f;
	public float jumpForce = 700f;

	bool grounded = false;
	bool facingRight = true;
	bool doubleJump = false;

	float groundRadius = 0.2f;

	Animator anim;

	bool jump;
	float xAxisValue;
	
	void Start () {
		anim = GetComponent<Animator> ();
	}


	void Update()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);
		
		if (grounded)
			doubleJump = false;
		
		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);


		#if MOBILE_INPUT
		jump = CrossPlatformInput.GetButton("Jump");
		xAxisValue = CrossPlatformInput.GetAxis("Horizontal");
		#endif
		
		#if UNITY_EDITOR
		jump = Input.GetButtonDown("Jump");
		xAxisValue = Input.GetAxis("Horizontal");
		#endif

		//anim.SetFloat ("Speed", Mathf.Abs (xAxisValue));
		
		rigidbody2D.velocity = new Vector2 (xAxisValue * maxSpeed, rigidbody2D.velocity.y);
		
		if (xAxisValue > 0 && !facingRight)
			Flip ();
		else if (xAxisValue < 0 && facingRight)
			Flip();

		if (jump) 
			Jump ();
	}

	void Move()
	{

	}

	void Jump(){
		if (grounded || !doubleJump) {
			anim.SetBool ("Ground", false);
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
			rigidbody2D.AddForce (new Vector2 (0, jumpForce));
			if (!doubleJump && !grounded) {
				doubleJump = true;
			}
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
