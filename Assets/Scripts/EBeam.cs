using UnityEngine;

public class EBeam : MonoBehaviour {

    float speed = 2.5f;
	
	void Update ()
	{
        transform.Translate(new Vector2(0f, -speed) * Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "GameObject")
        {
            Shoot com = collision.gameObject.GetComponent<Shoot>();
            if (com != null)
            {
                com.Upgrade(-2);
            }
            Destroy(gameObject);
        }
    }

}
