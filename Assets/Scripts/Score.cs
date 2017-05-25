using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] float pointsPerHalfSecond = 1;
    [SerializeField] Text text;
    public double startScore = 0;
    double score;

    IEnumerator TimeScore()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.5f);
            score += pointsPerHalfSecond;
        }
    }

	void Start ()
	{
        score = startScore;
        StartCoroutine(TimeScore());
	}
	
	void Update ()
	{
        text.text = "Score: " + score;
	}

    public void Bonus(float number)
    {
        score += number;
    }
}
