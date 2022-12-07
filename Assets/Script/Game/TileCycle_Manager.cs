using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCycle_Manager : MonoBehaviour
{
    public TileCycle _tileCycle = new TileCycle();
    

    void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        Init();
    }

    // 초기화 함수
    void Init()
    {
        _tileCycle.tcType = SetTileCycleType();

        switch (_tileCycle.tcType)
        {
            case Define.TileCylcle.AnswerFixed:
                SetAnswerFixed();
                break;
            case Define.TileCylcle.SymbolFixed:
                SetSymbolFixed();
                break;
        }
        _tileCycle._general = "=";
        /*
        // 정답일 때 시뮬레이션
        _tileCycle._firstNum = 1;
        _tileCycle._secondNum = 1;
        _tileCycle._answer = 2;

        _tileCycle.tileinfo = _tileCycle.SetTA();
        _tileCycle.CheckAnswer(_tileCycle.tileinfo);

        // 임시 값 대입
        _tileCycle.ChangeScore(ref score);
        _tileCycle.ChangeStamina(ref stamina);

        Debug.Log($"stamina: {stamina}, score: {score}");

        // 오답일 때 시뮬레이션
        _tileCycle._firstNum = 1;
        _tileCycle._secondNum = 1;
        _tileCycle._answer = 3;

        _tileCycle.tileinfo = _tileCycle.SetTA();
        _tileCycle.CheckAnswer(_tileCycle.tileinfo);

        // 임시 값 대입
        _tileCycle.ChangeScore(ref score);
        _tileCycle.ChangeStamina(ref stamina);

        Debug.Log($"stamina: {stamina}, score: {score}");
        */
    }

    // 타일사이클 종류 랜덤 세팅 함수
    Define.TileCylcle SetTileCycleType()
    {
        Define.TileCylcle randTC;

        if (this.tag.Equals("AnswerFixed"))
            randTC = Define.TileCylcle.AnswerFixed;
        else if(this.tag.Equals("SymbolFixed"))
            randTC = Define.TileCylcle.SymbolFixed;
        else
        {
            Debug.Log("Can't set TileCycle Type!");
            randTC = Define.TileCylcle.None;
        }

        return randTC;
    }


    // 정답고정 타일사이클 설정 함수
    void SetAnswerFixed()
    {
        // 고정할 정답 값 random 설정 후 저장
        _tileCycle._answer = SetRandAnswer();
        Debug.Log($"Fixed Answer Value is {_tileCycle._answer}");
    }

    // 기호고정 타일사이클 설정 함수
    void SetSymbolFixed()
    {
        // 고정할 기호 값 random 설정 후 저장
        _tileCycle._symbol = SetRandSymbol();
        Debug.Log($"Fixed Symbol Value is {_tileCycle._symbol}");
    }


    public int SetRandAnswer()
    {
        // 1~20 사이 랜덤 숫자 중 하나로 answer 세팅
        // 테스트하면서 확률 조정해야할 듯
        int rand = Random.Range(3, 16); // 범위 줄임
        if(rand == 13 || rand == 17 || rand == 19) // 소수 정답 방지
        {
            rand -= 1;
        }
        int answer = rand;
        return answer;
    }

    public string SetRandSymbol()
    {
        // 1~9 사이 랜덤 숫자 중 하나로 answer 세팅
        // 테스트하면서 확률 조정해야할 듯

        // 덧셈 뺄셈 곱셈 나눗셈 2:2:1:1로 비율 조정
        int rand = Random.Range(0,6);

        if (rand >= 0 && rand < 2)
            return "+";
        else if (rand >= 2 && rand < 4)
            return "-";
        else if (rand >= 4 && rand < 5)
            return "×";
        else
            return "÷";
    }
}
