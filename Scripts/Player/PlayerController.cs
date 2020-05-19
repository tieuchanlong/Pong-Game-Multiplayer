using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float enlargeSpeed = 2f;
    [SerializeField] private WeaponControl weapon;
    public enum AttackType  { ATTACK_ROD, ENLARGE };
    public AttackType Attack_Type;
    private Rigidbody rigid;

    [SyncVar] public float pos_X;
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        enemyController = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        BasicMovement();

        pos_X = transform.position.x;

        if (!hasAuthority)
        {
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            enemyController.SetPosx(pos_X);
        }

        //Attack();
        //Jump();
    }

    void BasicMovement()
    {
        if (!base.hasAuthority)
            return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        vertical = 0;

        transform.position = new Vector3(transform.position.x + horizontal * speed * Time.deltaTime, transform.position.y, transform.position.z + vertical * speed * Time.deltaTime);

    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Attack_Type == AttackType.ATTACK_ROD)
            {
                weapon.gameObject.SetActive(true);
                weapon.SetAttack();
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x + enlargeSpeed * Time.deltaTime, transform.localScale.y + enlargeSpeed * Time.deltaTime, transform.localScale.z + enlargeSpeed * Time.deltaTime);
                speed *= 0.9f;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            if (Attack_Type == AttackType.ATTACK_ROD)
            {
                weapon.gameObject.SetActive(true);
                weapon.SetAttack();
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x - enlargeSpeed * Time.deltaTime, transform.localScale.y - enlargeSpeed * Time.deltaTime, transform.localScale.z - enlargeSpeed * Time.deltaTime);
                speed /= 0.9f;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rigid.velocity += Vector3.up * 20;
    }

}
