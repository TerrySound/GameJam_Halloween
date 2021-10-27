using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundbankManager : MonoBehaviour
{
    public static SoundbankManager Instance;
    private bool bIsInitialized = false;

    [SerializeField] private List<AK.Wwise.Bank> Soundbanks;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(this);
            Debug.Log("Destroy");
        }

        if (!bIsInitialized)
        {
            if (Soundbanks.Count > 0)
            {
                Loadsoundbanks();
            }
            else
            {
                Debug.Log("List of soundbanks is empty");
            }
            bIsInitialized = true;
        }
    }

    void Loadsoundbanks()
    {
        foreach (AK.Wwise.Bank bank in Soundbanks)
            bank.Load();
        Debug.Log("Soundbanksloaded");
    }
}