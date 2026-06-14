using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clone : MonoBehaviour
{

    [SerializeField] GameObject player;
    public List<Vector3> playertransforms;

    public List<Vector3> posList;

    private Coroutine saveCoroutine;
    private Coroutine executeCoroutine;

    void Start()
    {
        saveCoroutine = StartCoroutine(savePlayerPosCoroutine());
        ResetLevel.Instance.OnPlayerRespawn += Loop;
    }

    [ContextMenu("Loop")]
    public void Loop()
    {
        if (saveCoroutine != null)
            StopCoroutine(saveCoroutine);

        if (executeCoroutine != null)
            StopCoroutine(executeCoroutine);

        posList = new List<Vector3>(playertransforms);

        playertransforms.Clear();

        executeCoroutine = StartCoroutine(ExecuteActionCoroutine());
        saveCoroutine = StartCoroutine(savePlayerPosCoroutine());
    }

    IEnumerator savePlayerPosCoroutine()
    {
        while (true)
        {
            playertransforms.Add(player.transform.position);
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator ExecuteActionCoroutine()
    {

        foreach (Vector3 pos in posList)
        {
            
            transform.position = Vector3.Lerp(transform.position,pos, 1);
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;

    }

}
