using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public int m_PlayerNumber = 1;//Player index.         
    public float m_Speed = 12f;           
    //public float m_TurnSpeed = 180f; Not sure do we need it? 

    /* TODO: SFX part     
    public AudioSource m_MovementAudio;    
    public AudioClip m_PlayerRunning;       
    public AudioClip m_PlayerWalking; 
    public float m_PitchRange = 0.2f;
    */

    private string m_MovementAxisName;
    private string m_JumpAxixName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_JumpInputValue;

    void Awake(){
		m_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable ()
	{
		m_Rigidbody.isKinematic = false;
		m_MovementInputValue = 0f;
	}

	void OnDisable(){
		m_Rigidbody.isKinematic = true;
	}

	// Use this for initialization
	void Start () {
		//Store imput axises name.
		m_MovementAxisName = "Horizontal" + m_PlayerNumber;
		m_JumpAxixName = "Vertical" + m_PlayerNumber;
	}

	
	// Update is called once per frame
	void Update () {
		//Store the player input value;
		m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
		m_JumpInputValue = Input.GetAxis(m_JumpAxixName);
	}

	private void FixedUpdate ()
	{
		//Player move and jump.
		Move();
		Jump();
	}

	void Move ()
	{
		// Adjust the position of the player based on the player's input.
        Vector3 movement = transform.right * m_MovementInputValue * m_Speed * Time.deltaTime;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
	}

	void Jump ()
	{
		// Adjust the position of the player based on the player's input.
		Vector3 jump = transform.up * m_JumpInputValue * m_Speed * Time.deltaTime;

		if (m_JumpInputValue > 0) {
			//Make jump upword speed faster.
			m_Rigidbody.MovePosition (m_Rigidbody.position + jump * 2);
		} else {
			m_Rigidbody.MovePosition (m_Rigidbody.position + jump);
		}
	}
}
