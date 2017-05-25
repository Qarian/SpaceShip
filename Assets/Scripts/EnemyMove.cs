using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed = 10;

    Transform target;
    int index = 1;
    public int way = 0;

	void Start ()
	{
        target = Routes.routes[way][index];
	}
	
	void Update ()
	{
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized *speed * Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(index >= Routes.routes[way].Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        index++;
        target = Routes.routes[way][index];
    }
}
