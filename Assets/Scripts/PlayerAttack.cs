using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;

    
    public int damage;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("HITTING");
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            
            // need to change this to hitbox/hurtbox
            Debug.Log("FOUND!");
            enemiesToDamage[i].GetComponent<PlayerMovement>().TakeDamage(damage);
        }
    }

    // red effect. can change
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}
