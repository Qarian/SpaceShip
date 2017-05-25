using UnityEngine;

public class Sound : MonoBehaviour {

    AudioSource sound;
    [Range(0, 1)] float vol = 0.8f;
    [Range(0, 1)] float shootVol = 0.5f;
    [Range(0, 1)] float musicVol = 1f;
    [SerializeField] AudioClip laser;
    [SerializeField] AudioClip enemyLaser;


	void Start ()
	{
        sound = GetComponent<AudioSource>();
	}

    public void EnemyLaser()
    {
        sound.PlayOneShot(enemyLaser, shootVol * vol * 0.8f);
    }

    public void Laser()
    {
        sound.PlayOneShot(laser,shootVol*vol);
    }

    #region change
    public void ChangeVol(float num)
    {
        vol = num * 0.1f;
    }

    public void ChangeSoundVol(float num)
    {
        vol = num * 0.1f;
    }

    public void ChangeMusicVol(float num)
    {
        vol = num * 0.1f;
    }
    #endregion
}
