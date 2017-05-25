using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

    Sound sound;
    Score score;

    [SerializeField] GameObject eBeam;
    [SerializeField] GameObject bonus;
    [SerializeField] float minTime = 0.4f;
    [SerializeField] float maxTime = 0.7f;
    [SerializeField] float live = 2f;
    [SerializeField] float points = 50f;
    [SerializeField] [Range(0,100)]float propabilityToDrop = 20f;

    void Start ()
	{
        StartCoroutine(Shoot());
        sound = FindObjectOfType<Sound>();
        score = FindObjectOfType<Score>();
    }

    public void Damage(float damage)
    {
        live -= damage;
        if (live <= 0)
            Boom();
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Instantiate(eBeam, transform.position - new Vector3(0,0.5f,0), Quaternion.identity);
            sound.EnemyLaser();
        }
    }

    private void Boom()
    {
        if (Random.Range(1f, 101f) <= propabilityToDrop)
        {
            Instantiate(bonus,transform.position,Quaternion.identity);
        }
        score.Bonus(points);
        Destroy(gameObject);
    }

}
