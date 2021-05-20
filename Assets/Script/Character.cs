using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("밀려나기 설정 => X:뒤 Y:높이")]
    public Vector2 hitPos;
    public float speed;

    float m_currTime;
    bool m_animation;
    Spine.TrackEntry m_entry;
    SkeletonAnimation m_spine;
    public Transform missilePos;
    Rigidbody2D rb2D;
    float startPosY;
    float startScale;


    public enum CharacterType
    {
        Rakstar,
        Muel,
        Turner
    }
    public CharacterType characterType;

    public void Awake()
    {
        
        m_spine = gameObject.GetComponent<SkeletonAnimation>();
        rb2D = GetComponent<Rigidbody2D>();
        startPosY = transform.position.y;
        startScale = transform.localScale.x;
    }

    //키보드로 조작되도록 되어 있음 숫자1:공격, 숫자2:공격당함, A키:왼쪽이동, D키:오른쪽이동
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(AttackAnimation());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDamage();
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-startScale, startScale);
            if (currentAniName != "walking")
                WalkAnimation();

            transform.Translate(Vector3.left * Time.deltaTime * speed);
            return;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(startScale, startScale);
            if (currentAniName != "walking")
                WalkAnimation();

            transform.Translate(Vector3.right * Time.deltaTime * speed);
            return;
        }

        if(transform.position.y < startPosY)
        {
            m_spine.skeleton.SetColor(Color.white);
            rb2D.isKinematic = true;
            rb2D.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, startPosY);
        }

        if (m_animation == false)
            return;

        m_currTime += Time.deltaTime;
        if (m_currTime < m_entry.AnimationEnd)
            return;

        m_animation = false;
        SetAnimation("idle", true);
    }

    //공격 애니메이션 호출 함수
    //캐릭터에 따라 총알을 발사할지, 파이어볼을 발사할지 결정하고 있음
    //SetAnimation("attack"); 해당 함수에 애니메이션이름을 넘겨주어 애니메이션을 호출함
    IEnumerator AttackAnimation()
    {
        SetAnimation("attack", false);

        yield return new WaitForSeconds(0.4f);
        if (characterType == CharacterType.Rakstar)
        {
            var missile =  Util.Instantiate("Bullet", missilePos.position, Quaternion.identity);
            missile.GetComponent<Missile>().TargetSetting(GameSceneManager.instance.bottomEnemyPos.position);
        }
        else if (characterType == CharacterType.Muel)
        {
            var missile = Util.Instantiate("Fireball", missilePos.position, Quaternion.identity);
            missile.GetComponent<Missile>().TargetSetting(GameSceneManager.instance.topEnemyPos.position);
        }
    }

    //SetAnimation("walking", true); 해당 함수에 애니메이션이름을 넘겨주어 애니메이션을 호출함
    public void WalkAnimation()
    {
        SetAnimation("walking", true);
    }


    //m_spine.state.SetAnimation(0, aniName, loop); 를 통해 애니메이션을 호출하고 있음.
    string currentAniName;
    public void SetAnimation(string aniName, bool loop)
    {
        if (m_spine.skeleton.Data.FindAnimation(aniName) == null)
        {
            Debug.Log(name);
            return;
        }

        m_currTime = 0;
        m_animation = true;
        currentAniName = aniName;
        m_entry = m_spine.state.SetAnimation(0, aniName, loop);
    }

    public void SetDamage()
    {
        m_spine.skeleton.SetColor(Color.red);
        Vector2 dir = transform.localScale.x > 0 ? new Vector2(-hitPos.x, hitPos.x) : new Vector2(hitPos.y, hitPos.y);
        rb2D.isKinematic = false;
        rb2D.AddForce(dir);
    }
}
