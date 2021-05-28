using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ranking : MonoBehaviour
{
    [SerializeField] private Transform[] girls;
    [SerializeField] private Transform boy;
    public TextMeshProUGUI rankingText;
    void Start()
    {
       
    }
    private int GetRankOfPlayer()
    {
        int counter = 1;
        for (int i = 0; i < girls.Length; i++)
        {
            if (girls[i].position.x < boy.position.x)
                counter++;
        }
        return counter;
    }

    // Update is called once per frame
    void Update()
    {
        rankingText.text = "Your Rank:"+GetRankOfPlayer().ToString() + "/10";
    }
}
