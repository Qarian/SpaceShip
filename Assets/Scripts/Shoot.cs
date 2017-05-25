using UnityEngine;

public class Shoot : MonoBehaviour {

    [SerializeField] GameObject beam;
    [SerializeField] float PointsPerBonus = 200f;

    Sound sound;
    Score score;
    Transform[] guns;
    public float fireRate = 0.2f;
    float lastFire;
    int fireLevel = 0;
    //tryby strzelania: poziom, lista broni 
    int[][] mode;

	void Start ()
	{
        score = FindObjectOfType<Score>();
        sound = GetComponent<Sound>();

        lastFire = Time.time - fireRate;
        
		foreach(Transform x in transform)
        {
            if (x.tag == "Guns")
            {
                int num = 0;
                guns = new Transform[x.childCount];
                foreach (Transform child in x)
                {
                    guns[num] = child.gameObject.GetComponent<Transform>();
                    num++;
                }
                break;
            }
        }

        mode = new int[5][];
            mode[0] = new int[1];
                mode[0][0] = 2;
            mode[1] = new int[2];
                mode[1][0] = 1;
                mode[1][1] = 3;
            mode[2] = new int[3];
                mode[2][0] = 0;
                mode[2][1] = 2;
                mode[2][2] = 4;
            mode[3] = new int[4];
                mode[3][0] = 0;
                mode[3][1] = 1;
                mode[3][2] = 3;
                mode[3][3] = 4;
            mode[4] = new int[5];
                mode[4][0] = 0;
                mode[4][1] = 1;
                mode[4][2] = 2;
                mode[4][3] = 3;
                mode[4][4] = 4;
    }
	
	void Update ()
	{
        if (Input.GetKey("space"))
        {
            if(Time.time-lastFire>=fireRate)
                Fire();
        }
	}

    void Fire()
    {
        lastFire = Time.time;
        foreach(int x in mode[fireLevel])
        {
            Instantiate(beam, new Vector3(guns[x].position.x, guns[x].position.y + 0.3f, guns[x].position.z), Quaternion.identity);
        }
        sound.Laser();
    }
    
    public void Upgrade(int number)
    {
        //4 - maxymalny level
        if (fireLevel+number > 4 && number>0)
        {
            fireLevel = 4;
            number = fireLevel + number - 4;
            score.Bonus(number*PointsPerBonus);
        }
        else if (fireLevel+number < 0 && number<0)
        {
            fireLevel = 0;
            //zadanie obrazen
        }
        else
            fireLevel+=number;
    }

}
