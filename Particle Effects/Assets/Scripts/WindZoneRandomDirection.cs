using UnityEngine;
using System.Collections;

public class WindZoneRandomDirection : MonoBehaviour {

    float timer = 0;
    float randdomTime = 5;
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer> randdomTime)
        {
            randdomTime = Random.Range(2, 5);

            Vector3 vectorRotate = new Vector3(Random.Range(0, 180), Random.Range(0, 360), 0);
            this.transform.rotation =   Quaternion.Euler(vectorRotate);
            timer = 0;

        }
	}
}
