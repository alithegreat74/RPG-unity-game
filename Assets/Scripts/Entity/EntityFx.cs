using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFx : MonoBehaviour
{
    [Header("Effect Material")]
    [SerializeField] private Material flashMat;
    [SerializeField] private float flashDuration;
    private SpriteRenderer sr;
    private Material originalMat;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat= sr.material;
    }

    private IEnumerator flash()
    {
        sr.material= flashMat;
        yield return new WaitForSeconds(flashDuration);
        sr.material= originalMat;
    }
    private void redBlink()
    {
        if(sr.color!= Color.white)
            sr.color= Color.white; 
        else
            sr.color= Color.red;
    }
    private void cancelBlink()
    {
        CancelInvoke();
        sr.color= Color.white;
    }

}
