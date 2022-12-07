using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wait3Sec : MonoBehaviour
{
    public TextMeshProUGUI sec;

    void Start()
    {
        Manager.Instance.PauseGame();
        StartCoroutine(wait3Sec());
        Manager.Instance.ContinueGame();
        Destroy(gameObject);
    }

    public IEnumerator wait3Sec()
    {
        sec.text = "3";
        yield return new WaitForSeconds(1.0f);
        sec.text = "2";
        yield return new WaitForSeconds(1.0f);
        sec.text = "1";
        yield return new WaitForSeconds(1.0f);
    }
}
