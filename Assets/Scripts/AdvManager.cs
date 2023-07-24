using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdvManager : MonoBehaviour
{
    bool isAdvAllowed = false;
    float advTimer;
    float advBreak = 70f;

    [DllImport("__Internal")]
    private static extern void ShowIntersitialAdvExtern();

    private void Start()
    {
        advTimer = advBreak;
    }
    private void Update()
    {
        advTimer -= Time.deltaTime;
        if (!isAdvAllowed && advTimer <= 0)
        {
            isAdvAllowed = true;
            
        }
    }

    public void ShowAdv()
    {
        if (isAdvAllowed)
        {
            isAdvAllowed = false;
#if !UNITY_EDITOR
            ShowIntersitialAdvExtern();
#endif
        }
    }

    public void StartTimer()
    {
        advTimer = advBreak;
    }
}
