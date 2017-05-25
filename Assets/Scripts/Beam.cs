using UnityEngine;

public class Beam : MonoBehaviour {

    public float speed = 2f;
    public float damage = 1f;

	void Update ()
	{
        transform.Translate(new Vector2(0f,speed)*Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "GameObject")
        {
            EnemyShoot com = collision.gameObject.GetComponent<EnemyShoot>();
            if(com != null)
            {
                com.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
}
