using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
   
    public int AllEnemies;          // кількість ворогів на лвл
    public int Count;               // кількість ворогів на полі
    public int CountMax;            // максимальна кількість чуваків на полі
    public static int Gogo;         // число що збільшується коли вбиваєш мобів
    public int GogoMax;             // розмір хвилі в раунді
    public static bool Summoning;
    public GameObject Enemy;
    public Transform[] RespawnSpot;
    public int RandomSpot;
    public int Zag;                 // заглушка для системи визову ворогів

    void Start()
    {
        Zag = 0;
        Gogo = 0;
        GogoMax = 0;
        Count = 0;
    }

    
    void Update()
    {
        if (Gogo>= GogoMax && Count < CountMax)
        {
            StartCoroutine(Wawe());
            GogoMax = Random.Range(2, 5);
            Zag = 0;
        }
        if (Count>=CountMax)
        {
            Summoning = false;
        }
    }

    IEnumerator Wawe()
    {
        Gogo = 0;
        yield return new WaitForSeconds(1);
        if (Summoning != false && Zag < GogoMax)
        {
            EnemySummon();
            Zag++;
        }
        yield return new WaitForSeconds(3f);
        if (Summoning != false && Zag < GogoMax)
        {
            EnemySummon();
            Zag++;
        }
        yield return new WaitForSeconds(3f);
        if (Summoning != false && Zag < GogoMax)
        {
            EnemySummon();
            Zag++;
        }
        yield return new WaitForSeconds(3f);
        if (Summoning != false && Zag < GogoMax)
        {
            EnemySummon();
            Zag++;
        }
        yield return new WaitForSeconds(3f);
        if (Summoning != false && Zag < GogoMax)
        {
            EnemySummon();
            Zag++;
        }
        yield return new WaitForSeconds(3f);
    }
    void EnemySummon()
    {
        RandomSpot = Random.Range(0, RespawnSpot.Length);
        Instantiate(Enemy, RespawnSpot[RandomSpot].position, Quaternion.identity);
    }
}

/*public int AMax, BMax, CMax, DMax, BossMax;
  public int ACount, BCount, Ccount, DCount;   */
