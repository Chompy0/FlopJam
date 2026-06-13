using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clone : MonoBehaviour
{

    [SerializeField] GameObject player;
    public List<Vector3> Playertransforms;

    public List<Vector3> posList;

    private Coroutine saveCoroutine;
    private Coroutine executeCoroutine;

    void Start()
    {
        saveCoroutine = StartCoroutine(savePlayerPosCoroutine());
    }

    [ContextMenu("Loop")]
    public void Loop()
    {
        if (saveCoroutine != null)
            StopCoroutine(saveCoroutine);

        if (executeCoroutine != null)
            StopCoroutine(executeCoroutine);

        posList = new List<Vector3>(Playertransforms);

        Playertransforms.Clear();

        executeCoroutine = StartCoroutine(ExecuteActionCoroutine());
        saveCoroutine = StartCoroutine(savePlayerPosCoroutine());
    }

    IEnumerator savePlayerPosCoroutine()
    {
        while (true)
        {
            Playertransforms.Add(player.transform.position);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator ExecuteActionCoroutine()
    {

        foreach (Vector3 pos in posList)
        {
            print(posList);
            transform.position = pos;
            print(transform.position);
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;

    }

}
