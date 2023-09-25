using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Entity : MonoBehaviour
{
    
    #region Vaiables
    public bool isBusy;
    [Header("Movement Info")]
    public float moveSpeed;
    public float jumpForce;
    public int facingDirection = 1;
    public float midAirSpeed;
    public float[] attackMovement;

    [Header("Collision Info")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Transform wallcheck;
    [SerializeField] protected float wallcheckDistance;
    public Transform attackPoint;
    public float attackRadius;

    [Header("KnockBack Info")]
    public bool isKnocked;
    [SerializeField] private Vector2 knockDirection;
    [SerializeField] private float knockDuration;

    [HideInInspector]public EntityFx entityFx;
    [HideInInspector] public CharacterStats stats;
    [HideInInspector] public bool isDead=false;
    #endregion
    #region Components
    public Animator animator { get;set; }
    public Rigidbody2D rb;
    #endregion

    protected virtual void Awake()
    {
        animator= GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        entityFx=GetComponent<EntityFx>();
        stats= GetComponent<CharacterStats>();
    }
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
    #region Movement
    public virtual void setVelocity(float x, float y)
    {
        if (isKnocked)
            return;
        rb.velocity=new Vector2(x, y);
    }
    public virtual void flip()
    {
        facingDirection*=-1;
        transform.Rotate(0, 180, 0);
    }
    public virtual void damage(int hitDirection)
    {
        Debug.Log(gameObject.name+" was hit");
        entityFx.StartCoroutine("flash");
        StartCoroutine("knockBack", hitDirection);
    }
    private IEnumerator knockBack(int hitDirection)
    {
        isKnocked=true;
        rb.velocity=new Vector2(hitDirection*knockDirection.x, knockDirection.y);
        yield return new WaitForSeconds(knockDuration);

        isKnocked = false;
    }
    #endregion
    #region Collision
    public virtual bool groundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    public virtual bool wallDetected() => Physics2D.Raycast(wallcheck.position, Vector2.down, wallcheckDistance, groundLayer);

    protected virtual async void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y-groundCheckDistance));
        Gizmos.DrawLine(wallcheck.position, new Vector2(wallcheck.position.x, wallcheck.position.y-wallcheckDistance));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    #endregion



}
