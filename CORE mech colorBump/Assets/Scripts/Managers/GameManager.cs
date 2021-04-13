using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region  Init
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
                Debug.LogError("GameManager is null");


            return _instance;
        }
    }

    void Awake() 
    {
        _instance = this;
    }
    #endregion 

    public GameObject Player;
    public Camera mainCamera;

    public GameObject finishLine;

    public BoxCollider boxCollCube;
    public SphereCollider sphereCollSmall;
    public SphereCollider sphereCollBig;
    public CapsuleCollider cylinderColl;

    public Vector3 positionFirstRow;
    public Material red,black,green;

    //Collision Check
    float MinX, MinY, MinZ;

    float MaxX, MaxY, MaxZ;    

    void Start()
    {
        PoolManager.Pool.Initialize();
    }




    public void SpawnRandomStack(Vector3 positionOfPlane)
    {
        
        //positionFirstRow.z += Random.Range(15f, 18f); 
        int spawnTryes = 1;
        while(spawnTryes > 0)
        {
            float randomNum = Random.value;
            Collider[] colliders = Physics.OverlapBox(new Vector3(positionOfPlane.x, positionOfPlane.y + 4, positionOfPlane.z),
                                   new Vector3(1, 1, 1),
                                   Quaternion.identity,
                                   3);
            if(colliders.Length == 0)
            {
                if(randomNum < 0.3)
                {
                    GameObject newObj = PoolManager.Pool.GetObjectForScene(ObjectEnums.SmallBallStack);
                    newObj.SetActive(true);
                    newObj.transform.position = new Vector3 (positionOfPlane.x,
                                                        positionOfPlane.y + sphereCollSmall.radius,
                                                        positionOfPlane.z);
                
                
                    Renderer[] gameObjectsColor =  newObj.GetComponentsInChildren<Renderer>();
                    foreach(Renderer color in gameObjectsColor)
                    {
                        if(color.tag == "Red")
                            color.material.color = Color.red;
                        else if(color.tag == "Green")
                            color.material.color = Color.green;
                        else if( color.tag == "Black")
                            color.material.color = Color.black;
                    }
                
                }
                else if(randomNum > 0.3 && randomNum < 0.4)
                {
                    GameObject newObj = PoolManager.Pool.GetObjectForScene(ObjectEnums.BigCube);
                    newObj.SetActive(true);
                    newObj.transform.position = new Vector3 (positionOfPlane.x,
                                                        positionOfPlane.y + boxCollCube.size.y * 1.5f,
                                                        positionOfPlane.z);
                
                    if(newObj.tag == "Red")
                        newObj.GetComponent<Renderer>().material.color = Color.red;
                    else if(newObj.tag == "Green")
                        newObj.GetComponent<Renderer>().material.color = Color.green;
                    else
                        newObj.GetComponent<Renderer>().material.color = Color.black;
                }       
                else if(randomNum > 0.4 && randomNum < 0.7)
                {
                    GameObject newObj = PoolManager.Pool.GetObjectForScene(ObjectEnums.BigBallLine);                    
                    newObj.transform.position = new Vector3 (positionOfPlane.x,
                                                        positionOfPlane.y,  //-sphereCollBig.radius,
                                                        positionOfPlane.z);


                    Renderer[] gameObjectsColor =  newObj.GetComponentsInChildren<Renderer>();
                    foreach(Renderer color in gameObjectsColor)
                    {
                        if(color.tag == "Red")
                        {
                            color.material.color = Color.red;
                        }
                        else if(color.tag == "Green")
                        {
                            color.material.color = Color.green;
                        }
                        else if( color.tag == "Black")
                        {
                            color.material.color = Color.black;
                        }
                    }
                    newObj.SetActive(true);
                
                }
                else
                {
                    GameObject newObj = PoolManager.Pool.GetObjectForScene(ObjectEnums.CylinderStack);                    
                    newObj.transform.position = new Vector3 (positionOfPlane.x,
                                                        positionOfPlane.y + 5,
                                                        positionOfPlane.z);

                    Renderer[] gameObjectsColor =  newObj.GetComponentsInChildren<Renderer>();
                    foreach(Renderer color in gameObjectsColor)
                    {
                        if(color.tag == "Red")
                            color.material.color = Color.red;
                        else if(color.tag == "Green")
                            color.material.color = Color.green;
                        else if( color.tag == "Black")
                            color.material.color = Color.black;
                    }
                    newObj.SetActive(true);
                }
                spawnTryes--;
            }
            else
            {
                spawnTryes--;
            }
        }
    }    
   

    void LateUpdate() {
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x,
                                                    mainCamera.transform.position.y,
                                                    (float)(Player.transform.position.z - 2.25));
    }
}
