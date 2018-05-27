using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneScript : MonoBehaviour, IPointerClickHandler {

    private Boolean selected = false;

	// Use this for initialization
	void Start () {
   }

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == gameObject.transform)
                {
                    handleClick();
                }
            }
        }

        
        gameObject.transform.Rotate(0f, 10*Time.deltaTime, 0f);
	}

    void CreateObjects(GameObject parent)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject sphere = (GameObject) Instantiate(Resources.Load("SmallSphere"));
            sphere.transform.parent = parent.transform;
            sphere.transform.localPosition = UnityEngine.Random.insideUnitSphere * 2;
        }

    }

    void DestroyObjects(GameObject parent)
    {
        Debug.Log("Destroying children.");
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        handleClick();
    }

    public void handleClick()
    {
        Debug.Log("Click detected.");
        selected = !selected;

        if (selected)
        {
            gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

            CreateObjects(gameObject);
        } else
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            DestroyObjects(gameObject);
        }
    }
}
