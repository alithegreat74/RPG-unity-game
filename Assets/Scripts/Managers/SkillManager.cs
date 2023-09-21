using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance
    {
        get
        {
            if (Instance == null)
                Instance = FindObjectOfType(typeof(SkillManager)) as SkillManager;

            return Instance;
        }
        set
        {
            instance = value;
        }
    }
    private static SkillManager Instance;

}
