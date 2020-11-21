using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTop : MonoBehaviour
{

    public Transform SpawnPointAz;
    public Transform SpawnPointCok;
    public GameObject terrainBall;
    public GameObject ShowBall;


    public Material one;
    public Material two;
    public Material three;
    public Material four;
    public Material five;
    public Material six;
    public Material seven;
    public Material eight;
    public Material nine;


    private int randomNumber;

 


    public void getNewBall()
    {
        Debug.Log("Yeni top getir pressed.");
        randomNumber = Random.Range(1, 9);
        showBallUpSideCube(randomNumber);
        Invoke("showTerrainBall", 3);
    }

    public void deleteAllBallInTerrain()
    {
        GameObject[] balls;

        balls = GameObject.FindGameObjectsWithTag("Top(Yeni)");

        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
    }

    private void showBallUpSideCube(int randomNumber)
    {
        GameObject showingBall;


        showingBall = Instantiate(ShowBall, ShowBall.transform.position,ShowBall.transform.rotation);
        showingBall = changeMaterial(randomNumber, showingBall);
        showingBall.transform.parent = GameObject.Find("MultiTarget").transform;
        showingBall.name = "TopGosteri";
        GameObject prevGameObject = ShowBall;
        ShowBall = showingBall;
        Destroy(prevGameObject);

    }

    private void showTerrainBall()
    {
        GameObject rigidPrefab;

        if(randomNumber > 4)
            rigidPrefab = Instantiate(terrainBall, SpawnPointCok.position, SpawnPointCok.rotation, gameObject.transform);
        else
            rigidPrefab = Instantiate(terrainBall, SpawnPointAz.position, SpawnPointAz.rotation, gameObject.transform);

        rigidPrefab.name = "Top(Yeni)";
        rigidPrefab.tag = "Top(Yeni)";
        rigidPrefab = changeMaterial(randomNumber, rigidPrefab);
        //rigidPrefab.transform.parent = gameObject.transform;
    }

    private GameObject changeMaterial(int randomNumber,GameObject gameobj)
    {
        switch (randomNumber) {
            case 1:
                gameobj.GetComponent<Renderer>().material = one; break;
            case 2:
                gameobj.GetComponent<Renderer>().material = two; break;
            case 3:
                gameobj.GetComponent<Renderer>().material = three; break;
            case 4:
                gameobj.GetComponent<Renderer>().material = four; break;
            case 5:
                gameobj.GetComponent<Renderer>().material = five; break;
            case 6:
                gameobj.GetComponent<Renderer>().material = six; break;
            case 7:
                gameobj.GetComponent<Renderer>().material = seven; break;
            case 8:
                gameobj.GetComponent<Renderer>().material = eight; break;
            case 9:
                gameobj.GetComponent<Renderer>().material = nine; break;
        }

        return gameobj;
    }
    
}
