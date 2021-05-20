using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    //미사일 타입을 설정함
    public enum MissileType
    {
        Bullet,
        Fireball,
    }
    public MissileType missileType;
    Vector2 targetEnemyPos;

    //미사일 타입에 따라 어떤 함수를 실행할것인지 결정함
    //targetEnemyPos = target; => 타겟설정, 미사일은 설정된 타겟을 향해 발사됨.
    public void TargetSetting(Vector2 target)
    {
        targetEnemyPos = target;
        if (missileType == MissileType.Bullet)
        {
            StartCoroutine(BulletCo());
        }
        if (missileType == MissileType.Fireball)
        {
            StartCoroutine(FireballCo());
        }
    }

    IEnumerator BulletCo()
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.MoveTowards(transform.position, targetEnemyPos, 10 * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetEnemyPos) < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator FireballCo()
    {
        while (true)
        {
            yield return null;
            if (transform.position.y < -2)
                Destroy(gameObject);

            float angle = Mathf.Atan2(targetEnemyPos.y, targetEnemyPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, targetEnemyPos, 10 * Time.deltaTime);

            if(Vector2.Distance(transform.position, targetEnemyPos) < 1)
            {
                Destroy(gameObject);
            }
        }
    }

    //미사일이 카메라밖으로 나갈 경우 제거됨
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
