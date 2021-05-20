using DevionGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerScript : MonoBehaviour
{
    public float Health;
    public int TeamNum;
    private GameObject dd;
    // Start is called before the first frame update
    void Start()
    {
        dd = GameObject.Find("GameManager");
        if(GameObject.Find("Canvas").FindChild("Connecting",true) == null)
        {
            if (TeamNum == 2)
            {
                Health = dd.GetComponent<GameManager>().selectStageNum * 50;
            }
            else
            {
                Health = 50;
            }
        }
        else
        {
            Health = 200;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 0)
            Health = 0;
        if(Health <=0)
        {
            Die();
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
    public void setHealth(float Damage)
    {
        Health -= Damage;
    }
}
