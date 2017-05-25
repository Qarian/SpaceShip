using UnityEngine;

public class Routes : MonoBehaviour {

    public static Transform[][] routes;

	void Awake ()
	{
        routes = new Transform[transform.childCount][];
        for (int i = 0; i < transform.childCount; i++)
        {
            routes[i] = new Transform[transform.GetChild(i).childCount];
            for (int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                routes[i][j] = transform.GetChild(i).GetChild(j);
            }
        }
	}
}
