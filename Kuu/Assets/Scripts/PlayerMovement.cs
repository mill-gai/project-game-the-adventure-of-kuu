using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float runSpeedOnSlime = 1f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float tiredLimit = 2f;
    [SerializeField] private float shrinkScale = 0.07f;
    [SerializeField] private ParticleSystem confettiEffect;
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody;
    private Vector2 moveInput;
    private BoxCollider2D playerCollider;
    private bool isTired, isOnSlime = false;
    private float prevRunSpeed;
    private float playerScale = 0.1f;
    private float tiredTimer;

    // ================= Helper Method =================
    private bool hasHorizontalMove()
    {
        return Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
    }

    private bool isTouching(string layerName)
    {
        int layerMask = LayerMask.GetMask(layerName);
        return playerCollider.IsTouchingLayers(layerMask);
    }
 
    private void setPlayerVelocity(float x, float y)
    {
        playerRigidbody.velocity = new Vector2(x, y);
    }

    private void setLayerCollision(string layerName, bool isIgnore){
        int playerLayer = LayerMask.NameToLayer("Player");
        int inputLayer = LayerMask.NameToLayer(layerName);
        Physics2D.IgnoreLayerCollision(playerLayer, inputLayer, isIgnore);
    }

    public bool getIsTired() { return isTired; }

    // =================================================
    private void Start(){
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
    }
 
    private void Update() {
        if(isTired) { 
            if(tiredTimer > tiredLimit){
                playerAnimator.SetBool("isTired", false);
                setLayerCollision("Enemy", false);
                isTired = false;
                tiredTimer = 0f;
            } else {
                tiredTimer += Time.deltaTime;
            }
        } else {
             Run();
             FlipPlayerSprite();
        }
    }  

    // ================= Input System ==================
    private void OnMove(InputValue value)
    {
        if(isTired) { return; }
        moveInput = value.Get<Vector2>();
    } 
    private void OnJump(InputValue value)
    {
        if(isOnSlime || isTired) { return; }
        if(isTouching("Platform") || isTouching("Interactable")){
            setPlayerVelocity(playerRigidbody.velocity.x, jumpSpeed);
        }
    } 

    private void OnCelebrate(InputValue value)
    {
        if(isOnSlime || isTired) { return; }
        confettiEffect.Play();
    }

    // =================================================
    private void Run()
    {
        if(playerRigidbody.velocity.y < Mathf.Epsilon && isTouching("Platform")){
            setPlayerVelocity(moveInput.x * runSpeed, 0f);
        } else {
            setPlayerVelocity(moveInput.x * runSpeed, playerRigidbody.velocity.y);
        }
        
        playerAnimator.SetBool("isMove", hasHorizontalMove());
    }

    private void FlipPlayerSprite()
    {
        if(hasHorizontalMove()){
            bool isShrink = moveInput.y > Mathf.Epsilon;
            if(isShrink){
                transform.localScale = new Vector2((Mathf.Sign(moveInput.x))*shrinkScale, playerScale);
            } else {
                transform.localScale = new Vector2((Mathf.Sign(moveInput.x))*playerScale, playerScale);
            }
        }
    }

    // ================= React to slime  ==================
    
    public void getIntoSlime()
    {
        isOnSlime = true;
        prevRunSpeed = runSpeed;
        runSpeed = runSpeedOnSlime;
    }

    public void getOutOfSlime()
    {
        isOnSlime = false;
        runSpeed = prevRunSpeed;
    }

    public void TakeDamage()
    {
        isTired = true;
        playerAnimator.Rebind();
        playerAnimator.SetBool("isTired", true);
        setLayerCollision("Enemy", true);
        playerRigidbody.velocity = new Vector2(5f, 5f);
    }


}
