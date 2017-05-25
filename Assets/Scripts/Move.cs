using UnityEngine;

public class Move : MonoBehaviour {

    [SerializeField] float speed = 10f;

    float horizontal;
    Animator animator;

	void Start ()
	{
        animator = GetComponent<Animator>();
	}
	
	void Update ()
	{
        horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Direction", horizontal);
        transform.Translate(new Vector2(horizontal,Input.GetAxis("Vertical")*0.5f)*speed*Time.deltaTime);
	}
}
