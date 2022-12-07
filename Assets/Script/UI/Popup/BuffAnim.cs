using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAnim : MonoBehaviour
{
    float time = 0;
    float blinkTime = 0.1f;
    float xtime = 0;
    float waitTime = 0.2f;

    void Update()
    {
        if (xtime < blinkTime)
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - xtime * 10);
        else if (xtime<waitTime*blinkTime)
        {

        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, (xtime - (waitTime + blinkTime)) * 10);

            if(xtime>waitTime + blinkTime * 2)
            {
                xtime = 0;
                waitTime *= 0.8f;
                if(waitTime < 0.02f)
                {
                    time = 0;
                    waitTime = 0.2f;
                    this.gameObject.SetActive(false);
                }
            }
            xtime += Time.deltaTime;
        }
        time += Time.deltaTime;
    }
}
