using UnityEngine;

public class UnitClass : MonoBehaviour
{
    private float Maxspeed;
    private float Health;
    private int TeamNum;

    public UnitClass() // 기본 생성자
    {
        this.Maxspeed = 1;
        this.Health = 100;
        this.TeamNum = 1;
    }
    public UnitClass(string _Name) // 유닛 명을 바탕으로 한 생성자
    {
        if(_Name == "sword")
        {
            this.Maxspeed = 1;
            this.Health = 200;
            this.TeamNum = 1;
        }
    }

    public void setMaxspeed(float maxspeed) // 최대속도 설정
    {
        this.Maxspeed = maxspeed;
    }
    public float getMaxspeed() // 최대속도 얻어오기
    {
        return this.Maxspeed;
    }

    public void setHealth(float health) // 체력 설정
    {
        this.Health = health;
    }
    public float getHealth() // 체력 값 얻어오기
    {
        return this.Health;
    }

    public void setTeamnum(int teamnum) // 팀 번호 설정
    {
        this.TeamNum = teamnum;
    }
    public int getTeamnum() // 팀 번호 얻어오기
    {
        return this.TeamNum;
    }

    public void Damaged(float damage) // 데미지를 받으면 체력을 낮춰줌
    {
        this.Health -= damage;
    }
    public void Die()
    {

    }
    public void Move()
    {

    }
}
