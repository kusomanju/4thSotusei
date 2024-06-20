using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    [SerializeField] private GameObject TV;
    [SerializeField] private GameObject Drink;
    [SerializeField] private Transform Spawn;
    [SerializeField] private Transform Origin;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        if (NMeCab_test.TV_On)
        {
            TV.SetActive(true);
            NMeCab_test.TV_On = false;
            Debug.Log("TVON");
        }
        if (NMeCab_test.TV_OFF)
        {
            TV.SetActive(false);
            NMeCab_test.TV_OFF = false;
            Debug.Log("TVOFF");
        }

        if (NMeCab_test.Take_Drink)
        {
            Drink.transform.position = Spawn.position;
            NMeCab_test.Take_Drink = false;
            Debug.Log("DRINK TAKE");
        }
        if (NMeCab_test.Put_Drink)
        {
            Drink.transform.position=Origin.position;
            NMeCab_test.Put_Drink = false;
            Debug.Log("DRINK PUT");
        }
    }
}
