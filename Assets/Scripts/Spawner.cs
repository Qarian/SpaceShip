using System.Collections;
using UnityEngine;
using System;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject enemy;
    float time = 0.5f;
    Transform[] points;
    int num = 1;
    int way = 0;

    void Start ()
	{
        points = new Transform[Routes.routes.Length];
        for (int i = 0; i < Routes.routes.Length; i++)
        {
            points[i] = Routes.routes[i][0];
        }
    }

    public void Spawn(int number)
    {
        StartCoroutine(Wave(num, way, time));
    }

    public void ChangeWay(string number)
    {
        way = Int32.Parse(number)-1;
        if (way >= Routes.routes.Length)
            way = Routes.routes.Length - 1;
    }

    public void ChangeTime(string number)
    {
        time = 1/float.Parse(number);
    }

    public void ChangeNumber(string number)
    {
        num = Int32.Parse(number);
    } 

    IEnumerator Wave(int number,int way, float time)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject ene = Instantiate(enemy, points[way].position, Quaternion.identity);
            ene.GetComponent<EnemyMove>().way = way;
            yield return new WaitForSeconds(time);
        }
    }
}
