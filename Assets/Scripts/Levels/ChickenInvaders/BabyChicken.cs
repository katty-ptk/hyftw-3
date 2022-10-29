using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyChicken : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("MoveRandomly", 1.0f, Random.Range(1f, 4f));
    }

    private void MoveRandomly()
    {
        GetComponent<Transform>().DOMove(new Vector3(Random.Range(-8, 8), Random.Range(-3, 4.3f), 0), 1f);
    }
}
