using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public void StaminaPlus()
    {
        Manager.Instance.updateStamina(1);
    }

    public void StaminaMinus()
    {
        Manager.Instance.updateStamina(-1);
    }

    public void ScorePlus()
    {
        Manager.Instance.updateScore(20);
    }

    public void ScoreMinus()
    {
        Manager.Instance.updateScore(-8);
    }

    public void GemPlus()
    {
        Manager.Instance.updateGem(10);
    }

    public void GemMinus()
    {
        Manager.Instance.updateGem(-10);
    }

    public void FeverPlus()
    {
        Manager.Instance.PlusFeverGaugeValue();
    }
}
