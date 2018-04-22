using UnityEngine;
using System.Collections;

public class FlickeringLight : MonoBehaviour {


	public GameObject testLight;
	public float minWaitTime;
	public float maxWaitTime;
    public float duration;
    private float count;
    private bool start, enabled;

	void Start () {
        count = 0.0f;
        start = false;
        enabled = false;
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing ()
	{
        if (start)
        {
            count += Time.deltaTime;
            if (count < duration)
            {
                yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
                enabled = !enabled;
                testLight.SetActive(enabled);
            }
        }
	}

    public void StartFlicker()
    {
        start = true;
    }
}