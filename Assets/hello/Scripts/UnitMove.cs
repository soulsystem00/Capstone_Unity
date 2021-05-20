using DevionGames;
using System;
using System.Security;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class UnitMove : MonoBehaviour
{
    public float MAXSPEED;
    public float AttackSpeed;
    public float AttackRange;
    public float Health;
    public int TeamNum;
    public int Cost;
    public int Damage;
    public float second;
    //Transform transform;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sprite;
    UnitMove enemy;
    TowerScript tower;
    BoxCollider2D boxcol;
    CapsuleCollider2D capcol;
    Transform rect;

    //audio
    public AudioSource audioSource;
    public AudioClip Sound_Attack;
    public AudioClip Sound_Die;
    public AudioClip Sound_Move;
    // Start is called before the first frame update

    public int death_count;

    public bool scene_checker;
    void Play_Sound(string name)
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().Effect_ON_OFF)
        {
            if (name == "Attack")
            {
                if (Sound_Attack != null)
                {
                    audioSource.clip = Sound_Attack;
                    audioSource.Play();
                }

            }
            else if (name == "Die")
            {
                if (Sound_Die != null)
                {
                    audioSource.clip = Sound_Die;
                    audioSource.Play();
                }

            }
            else if (name == "Move")
            {
                if (Sound_Move != null)
                {
                    audioSource.clip = Sound_Move;
                    audioSource.Play();
                }
            }
        }


    }
    void Start()
    {
        scene_checker = GameObject.Find("Canvas").FindChild("Connecting", true) != null;
        //transform = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        boxcol = GetComponent<BoxCollider2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        death_count = 0;
        //rect = transform.Find("bar");
        //gameObject.layer = TeamNum + 9;


    }

    void FixedUpdate()
    {
        
        if (!animator.GetBool("Detect"))
        {
            Move();
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }
        if(scene_checker)
        {
            if (Health <= 0)
            {
                Die();
            }
            else
            {
                revive();
            }
        }
        else
        {
            if (Health <= 0)
            {
                Die();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //try
        //{
        //    if (collision.GetComponent<BoxCollider2D>().IsTouching(capcol))
        //    {
        //        AttackAnimationTrue(collision);
        //        Debug.Log(this.name + capcol.IsTouching(collision));
        //    }
        //}
        //catch (Exception e)
        //{
        //    Debug.Log(e);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<BoxCollider2D>().IsTouching(capcol))
        {
            AttackAnimationTrue(collision);
            //Debug.Log(this.name + capcol.IsTouching(collision));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AttackAnimationFalse(collision);
    }

    private void OnDestroy()
    {
        Resources.UnloadUnusedAssets();
    }
    private void Move()
    {

        if (TeamNum == 1)
        {
            rigid.AddForce(new Vector2(1f, 0f), ForceMode2D.Impulse);
            if (rigid.velocity.x > MAXSPEED)
            {
                rigid.velocity = new Vector2(MAXSPEED, rigid.velocity.y);
                //Debug.Log("move1");
            }

        }
        else
        {
            rigid.AddForce(new Vector2(-1f, 0f), ForceMode2D.Impulse);
            //sprite.flipX = true;
            if (rigid.velocity.x < -1 * MAXSPEED)
            {
                rigid.velocity = new Vector2(-1 * MAXSPEED, rigid.velocity.y);
                //Debug.Log("move2");
            }

        }

    }
    private void Attack()
    {
        if (enemy != null)
        {
            //Debug.Log(enemy.name);
            if (enemy.TeamNum != TeamNum)
            {
                rigid.velocity = new Vector2(0, 0);
                enemy.setHealth(Damage);
            }

        }
        if (tower != null)
        {
            if (tower.TeamNum != TeamNum)
            {
                rigid.velocity = new Vector2(0, 0);
                tower.setHealth(Damage);
            }

        }

    }

    private void Die()
    {
        capcol.enabled = false;
        boxcol.enabled = false;
        rigid.constraints = RigidbodyConstraints2D.FreezePosition;
        //Debug.Log("Die");
        //boxcol.enabled = false;
        animator.SetTrigger("Die");
    }
    private void revive()
    {
        capcol.enabled = true;
        boxcol.enabled = true;
        rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        gameObject.SetActive(true);
    }
    private void _Destory()
    {
        if(GameObject.Find("Canvas").FindChild("Connecting", true) == null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
        
    }
    public void setHealth(float Damage)
    {
        Health -= Damage;
    }

    public void AttackAnimationTrue(Collider2D collision)
    {
        if (collision.gameObject.name != "ground" || collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log(collision.name);
            if (collision.gameObject.GetComponent<UnitMove>() != null)
            {
                enemy = collision.gameObject.GetComponent<UnitMove>();
            }
            if (collision.gameObject.GetComponent<TowerScript>() != null)
            {
                tower = collision.gameObject.GetComponent<TowerScript>();
            }

            if (enemy == null)
            {
                if (tower.TeamNum != TeamNum)
                {
                    animator.SetBool("Detect", true);
                }
            }
            else
            {
                if (enemy.TeamNum != TeamNum)
                {
                    animator.SetBool("Detect", true);
                }
            }

        }
    }
    public void AttackAnimationFalse(Collider2D collision)
    {
        //if(enemy != null)
        //{
        //    if (collision.gameObject.name != "Ground" && enemy.TeamNum != TeamNum)
        //    {
        //        animator.SetBool("Detect", false);
        //    }
        //}
        //if(tower != null)
        //{
        //    if (collision.gameObject.name != "Ground" && tower.TeamNum != TeamNum)
        //    {
        //        animator.SetBool("Detect", false);
        //    }
        //}
        animator.SetBool("Detect", false);
        enemy = null;
        tower = null;
    }

    public void Astronaut()
    {
        GameObject rifle_side_cover = gameObject.FindChild("rifle_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_rifle_side", true);
        GameObject rifle_side = gameObject.FindChild("rifle_side", true);
        GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(true);
        weapon_rifle_side.SetActive(true);
        rifle_side.SetActive(true);
        muzzleflash_rifle.SetActive(true);

        try
        {
            sprite.enabled = false;
        }
        catch
        {

        }
    }
    public void Astronaut_Disable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("rifle_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_rifle_side", true);
        GameObject rifle_side = gameObject.FindChild("rifle_side", true);
        GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        muzzleflash_rifle.SetActive(false);
        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }


    }
    public void AstronautDie()
    {
        GameObject rifle_side_cover = GameObject.Find("rifle_side_cover");
        GameObject weapon_rifle_side = GameObject.Find("weapon_rifle_side");
        GameObject rifle_side = GameObject.Find("rifle_side");
        GameObject muzzleflash_rifle = GameObject.Find("muzzleflash_rifle");
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        muzzleflash_rifle.SetActive(false);

        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }
        //Destroy(gameObject);
        _Destory();
    }
    public void AstronautDie_2()
    {
        //Destroy(gameObject);
        _Destory();


    }
    public void Astronaut_hammer_enable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("hammer_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_hammer_side", true);
        GameObject rifle_side = gameObject.FindChild("hammer_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(true);
        weapon_rifle_side.SetActive(true);
        rifle_side.SetActive(true);
        //muzzleflash_rifle.SetActive(true);

        try
        {
            sprite.enabled = false;
        }
        catch
        {

        }
    }

    public void Astronaut_hammer_disable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("hammer_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_hammer_side", true);
        GameObject rifle_side = gameObject.FindChild("hammer_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        //muzzleflash_rifle.SetActive(true);
        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }
    }
    public void Astronaut_hammer_Die_1()
    {
        GameObject rifle_side_cover = GameObject.Find("hammer_side_cover");
        GameObject weapon_rifle_side = GameObject.Find("weapon_hammer_side");
        GameObject rifle_side = GameObject.Find("hammer_side");
        //GameObject muzzleflash_rifle = GameObject.Find("muzzleflash_rifle");
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        //muzzleflash_rifle.SetActive(false);

        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }
    }
    public void Astronaut_hammer_Die()
    {
        //Destroy(gameObject);
        _Destory();
    }

    public void Astronaut_sword_enable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("sword_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_sword_side", true);
        GameObject rifle_side = gameObject.FindChild("sword_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(true);
        weapon_rifle_side.SetActive(true);
        rifle_side.SetActive(true);
        //muzzleflash_rifle.SetActive(true);

        try
        {
            sprite.enabled = false;
        }
        catch
        {

        }
    }

    public void Astronaut_sword_disable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("sword_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_sword_side", true);
        GameObject rifle_side = gameObject.FindChild("sword_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        //muzzleflash_rifle.SetActive(true);
        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }
    }
    public void Astronaut_sword_Die()
    {
        //Destroy(gameObject);
        _Destory();
    }

    public void Astronaut_sycthe_enable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("sycthe_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_sycthe_side", true);
        GameObject rifle_side = gameObject.FindChild("sycthe_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(true);
        weapon_rifle_side.SetActive(true);
        rifle_side.SetActive(true);
        //muzzleflash_rifle.SetActive(true);

        try
        {
            sprite.enabled = false;
        }
        catch
        {

        }
    }

    public void Astronaut_sycthe_disable()
    {
        GameObject rifle_side_cover = gameObject.FindChild("sycthe_side_cover", true);
        GameObject weapon_rifle_side = gameObject.FindChild("weapon_sycthe_side", true);
        GameObject rifle_side = gameObject.FindChild("sycthe_side", true);
        //GameObject muzzleflash_rifle = gameObject.FindChild("muzzleflash_rifle", true);
        rifle_side_cover.SetActive(false);
        weapon_rifle_side.SetActive(false);
        rifle_side.SetActive(false);
        //muzzleflash_rifle.SetActive(true);
        try
        {
            sprite.enabled = true;
        }
        catch
        {

        }
    }
    public void Astronaut_sycthe_Die()
    {
        //Destroy(gameObject);
        _Destory();
    }

}