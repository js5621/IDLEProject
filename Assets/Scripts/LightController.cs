using DG.Tweening;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public SpawnSO spawnSO;
    Spawner spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = FindAnyObjectByType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawner.isLightReset)
        {
            this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.red, 0.1f);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if(!spawner.isLightReset)
        {
            if (other.gameObject.tag == "Player")
            {
                this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.green, 0.1f);
            }

            if (other.gameObject.tag == "EnemyAlien")
            {
                if (this.transform.GetChild(0).GetComponent<Light>().color == Color.green)
                {
                    Destroy(other.gameObject, 0.5f);
                    this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.red, 0.1f);
                    spawnSO.recentPoint += 10;

                }

            }
        }

    }


}
