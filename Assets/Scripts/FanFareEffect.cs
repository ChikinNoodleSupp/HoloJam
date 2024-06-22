using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class FanFareEffect : MonoBehaviour
{

    private float originalTime;

    
    public void TriggerFanfare(float fanfareTime, float moneyTimeChange)
    {
        StartCoroutine(Fanfare(fanfareTime, moneyTimeChange));
    }

    

    IEnumerator Fanfare(float fanfareTime, float moneyTimeChange)
    {
        if (GetComponent<OSHI>() != null)
        {
            OSHI oshi = GetComponent<OSHI>();
            originalTime = oshi.moneyTime;
            oshi.moneyTime = oshi.moneyTime / moneyTimeChange;
            yield return new WaitForSeconds(fanfareTime);
            oshi.moneyTime = originalTime;

        }
        if (GetComponent<OSSSHI>() != null)
        {
            OSSSHI ossshi = GetComponent<OSSSHI>();
            originalTime = ossshi.moneyTime;
            ossshi.moneyTime = ossshi.moneyTime / moneyTimeChange;
            yield return new WaitForSeconds(fanfareTime);
            ossshi.moneyTime = originalTime;
        }
        if (GetComponent<Oshit>() != null)
        {
            Oshit oshit = GetComponent<Oshit>();
            originalTime = oshit.moneyTime;
            oshit.moneyTime = oshit.moneyTime / moneyTimeChange;
            yield return new WaitForSeconds(fanfareTime);
            oshit.moneyTime = originalTime;
        }

       Destroy(this);
        yield return null;
    }

}
