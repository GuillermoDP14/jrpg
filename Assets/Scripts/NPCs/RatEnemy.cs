using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EnemyState{
    idle,
    walk,
    stagger
}

public class RatEnemy : Enemy
{


    public EnemyState currentState;
    public Transform target;
    public float chaseRaidus;
    public Transform homePosition;
    private Rigidbody2D myRigidbody;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target !=null){
            CheckDistance();
        }else if (SceneManager.GetActiveScene().name == "Macael")
        {  
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void CheckDistance(){

        if(Vector3.Distance(target.position, transform.position) <= chaseRaidus)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

            
            Vector2 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            myRigidbody.MovePosition(temp);
            ChangeAnim(new Vector2(temp.x, temp.y) - new Vector2(transform.position.x, transform.position.y));
            ChangeState(EnemyState.walk);   
            animator.SetBool("walking", true);  
            
            }        
        }else if (Vector3.Distance(target.position, transform.position) > chaseRaidus){
            animator.SetBool("walking", false);  
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        animator.SetFloat("movX", setVector.x);
        animator.SetFloat("movY", setVector.y);
    }

    void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            } 
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if(direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
             
        
    }
    
    void ChangeState(EnemyState newState){

        if(currentState != newState)
        {
           currentState = newState;
        }        
    }
}
