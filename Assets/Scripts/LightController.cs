using DG.Tweening;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public SpawnSO spawnSO;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.green,0.1f);
        }

        if (other.gameObject.tag =="EnemyAlien")
        {
            if(this.transform.GetChild(0).GetComponent<Light>().color == Color.green)
            {
                Destroy(other.gameObject,0.5f);
                this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.red, 0.1f);
                if(spawnSO.SpawnMonsterCount>0)
                {
                    spawnSO.SpawnMonsterCount -= 1;
                }
                
            }
            
        }
    }


}
