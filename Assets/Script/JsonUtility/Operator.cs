/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OCount
{
    public int plus;
    public int minus;
    public int multiply;
    public int divide;
}
public class Operator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SaveOperatorCount(int pl, int mi, int mul, int div)
    {

        OCount count = new OCount();
        OCount SaveOperator = LoadOperatorCount();
        if(pl == 1)
        {
            count.plus = SaveOperator.plus++;
        }
        else
        {
            count.plus = SaveOperator.plus;
        }
        if (mi == 1)
        {
            count.minus = SaveOperator.minus++;
        }
        else
        {
            count.minus = SaveOperator.minus;
        }
        if (mul == 1)
        {
            count.multiply = SaveOperator.multiply++;
        }
        else
        {
            count.multiply = SaveOperator.multiply;
        }
        if (div == 1)
        {
            count.divide = SaveOperator.divide++;
        }
        else
        {
            count.divide = SaveOperator.divide;
        }


        string json = JsonUtility.ToJson(count);
        Debug.Log(json + " 연산자 사용 횟수 DB저장");

        string fileName = "OperatorCount1";
        string path = Application.dataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public OCount LoadOperatorCount()
    {
        string fileName = "OperatorCount1";
        string path = Application.dataPath + "/" + fileName + ".Json";
        string json = File.ReadAllText(path);
        OCount count = JsonUtility.FromJson<OCount>(json);

        Debug.Log(count + "저장된 연산자 사용 횟수");
        return count;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OCount
{
    public int plus;
    public int minus;
    public int multiply;
    public int divide;
}
public class Operator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SaveOperatorCount(string symbol)
    {

        OCount count = new OCount();
        OCount SaveOperator = LoadOperatorCount();

        // 지우 수정
        switch (symbol)
        {
            case "+":
                count.plus = SaveOperator.plus++;
                break;
            case "-":
                count.minus = SaveOperator.minus++;
                break;
            case "×":
                count.multiply = SaveOperator.multiply++;
                break;
            case "÷":
                count.plus = SaveOperator.divide++;
                break;
            default:
                break;
        }
        
        string json = JsonUtility.ToJson(count);
        Debug.Log(json + " 연산자 사용 횟수 DB저장");

        string fileName = "OperatorCount1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        File.WriteAllText(path, json);
    }

    public OCount LoadOperatorCount()
    {
        string fileName = "OperatorCount1";
        string path = Application.persistentDataPath + "/" + fileName + ".Json";
        string json;
        OCount defaultCount = new OCount();
        try
        {
            json = File.ReadAllText(path);
        }
        catch
        {
            defaultCount.plus = 0;
            defaultCount.minus = 0;
            defaultCount.multiply = 0;
            defaultCount.divide = 0;
            return defaultCount;
        }
        OCount count = JsonUtility.FromJson<OCount>(json);

        Debug.Log(count + "저장된 연산자 사용 횟수");
        return count;

    }
}
