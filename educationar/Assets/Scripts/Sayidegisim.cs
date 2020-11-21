using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayidegisim : MonoBehaviour
{
    private static GameObject numbersGroup;

    private RaycastHit _hit;
    private Ray _ray;

    private static GameObject selectedNumberGameObject;
    private static int selectedNumber;


    // Use this for initialization
    void Start()
    {
        numbersGroup = GameObject.Find("sayigrup");
        selectedNumberGameObject = numbersGroup.gameObject.transform.GetChild(0).gameObject;
        selectedNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("tıklabana");
                if (_hit.collider.gameObject.name == "geri")
                {
                    // Write things you want to do when you click.
                    Debug.Log("Clicked to prev button");
                    selectedNumberGameObject.gameObject.SetActive(false);

                    selectedNumber = selectedNumber - 1;
                    if (selectedNumber <= -1)
                    {
                        selectedNumber = 9;
                    }
                    selectedNumberGameObject = numbersGroup.gameObject.transform.GetChild(selectedNumber).gameObject;
                    selectedNumberGameObject.gameObject.SetActive(true);
                    //selectedNumberGameObject.gameObject.transform.position = new Vector3(0, 1, 0);


                }
                else if (_hit.collider.gameObject.name == "ileri")
                {
                    Debug.Log("Clicked to next button");
                    selectedNumberGameObject.gameObject.SetActive(false);

                    selectedNumber = selectedNumber + 1;
                    if (selectedNumber >= 10)
                    {
                        selectedNumber = 0;
                    }
                    selectedNumberGameObject = numbersGroup.gameObject.transform.GetChild(selectedNumber).gameObject;
                    selectedNumberGameObject.gameObject.SetActive(true);
                    //selectedNumberGameObject.gameObject.transform.position = new Vector3(0, 1, 0);

                }

            }

        }
    }

  
}
