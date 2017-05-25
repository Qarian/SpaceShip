using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] float gravity = -0.1f;
	
	void Update ()
	{
        transform.Translate(new Vector2(0f,gravity)*Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "GameObject")
        {
            Shoot com = collision.GetComponent<Shoot>();
            if (com != null)
            {
                com.Upgrade(1);
            }
            Destroy(gameObject);
        }
    }
}
