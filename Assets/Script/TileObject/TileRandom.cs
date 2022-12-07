using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandom : MonoBehaviour
{
    [SerializeField] private GameObject[] tile;

    int seed;

    private void Awake()
    {
        seed = (int)((this.GetHashCode()) * (float)this.transform.position.z * Random.Range(1, 999));
    }


    private void OnEnable()
    {
        Random.InitState(seed);
        int randomNum = Random.Range(0, 999);

        if (randomNum % 2 != 0) // 확률... 나중에 수정
        {
            tile[0].SetActive(true);
            tile[1].SetActive(false);
        }
        else
        {
            tile[1].SetActive(true);
            tile[0].SetActive(false);
        }
    }





}
