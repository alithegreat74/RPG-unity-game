using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;

            return Instance;
        }
        set
        {
            instance = value;
        }
    }
    private static PlayerManager Instance;
    public Player player;


    

}
