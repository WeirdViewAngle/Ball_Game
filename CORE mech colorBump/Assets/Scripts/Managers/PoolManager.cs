using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region  Init


    //Objects to pull
    

    static PoolManager _pool;
    public static PoolManager Pool
    {
        get
        {
            if(_pool == null)
                Debug.LogError("Pool is Null");
            

            return _pool;
        }
    }

    void Awake() 
    {
        _pool = this;
    }
    #endregion

    public GameObject SmallBallStack;
    public GameObject BigCube;
    public GameObject BigBallLine;
    public GameObject CylinderStack;
    public void Initialize()
    {
        _objectsPool.Add(ObjectEnums.SmallBallStack, new List<GameObject>());        
        _objectsPool.Add(ObjectEnums.BigCube, new List<GameObject>());        
        _objectsPool.Add(ObjectEnums.BigBallLine, new List<GameObject>());
        _objectsPool.Add(ObjectEnums.CylinderStack, new List<GameObject>());

        for(int i = 0;i < 4;i++)
        {
            _objectsPool[ObjectEnums.SmallBallStack].Add(AddNewObject(ObjectEnums.SmallBallStack));            
            _objectsPool[ObjectEnums.BigCube].Add(AddNewObject(ObjectEnums.BigCube));            
            _objectsPool[ObjectEnums.BigBallLine].Add(AddNewObject(ObjectEnums.BigBallLine));
            _objectsPool[ObjectEnums.BigBallLine].Add(AddNewObject(ObjectEnums.CylinderStack));
        }
    }

    #region  Dict
    static Dictionary<ObjectEnums, List<GameObject>> _objectsPool
     = 
        new Dictionary<ObjectEnums, List<GameObject>>();


    public static Dictionary<ObjectEnums, List<GameObject>> ObjectsPool
    {
        get
        {
            return _objectsPool;
            
        }
        set
        {
            _objectsPool = value;
        }
    }
    #endregion 
    
    public GameObject AddNewObject(ObjectEnums name)
    {
        if(name == ObjectEnums.SmallBallStack)
        {
            GameObject newGO = GameObject.Instantiate(SmallBallStack, Camera.main.transform.position,Quaternion.identity);
            newGO.gameObject.SetActive(false);
            GameObject.DontDestroyOnLoad(newGO);
            _objectsPool[name].Add(newGO);
            return(newGO);
        }
        else if(name == ObjectEnums.BigBallLine)
        {
            GameObject newGO = GameObject.Instantiate(BigBallLine, Camera.main.transform.position,Quaternion.identity);
            newGO.gameObject.SetActive(false);
            GameObject.DontDestroyOnLoad(newGO);
            _objectsPool[name].Add(newGO);
            return(newGO);
        }
        else if(name == ObjectEnums.BigCube)
        {
            GameObject newGO = GameObject.Instantiate(BigCube, Camera.main.transform.position,Quaternion.identity);
            newGO.gameObject.SetActive(false);
            GameObject.DontDestroyOnLoad(newGO);
            _objectsPool[name].Add(newGO);

            float randomColorCube = UnityEngine.Random.value;
            if(randomColorCube < 0.3)
                newGO.tag = "Red";
            else if(randomColorCube > 0.3 && randomColorCube < 0.6)
                newGO.tag = "Green";
            else
                newGO.tag = "Black";

            return(newGO);
        }
        else
        {
            GameObject newGO = GameObject.Instantiate(CylinderStack, Camera.main.transform.position,Quaternion.identity);
            newGO.gameObject.SetActive(false);
            GameObject.DontDestroyOnLoad(newGO);
            _objectsPool[name].Add(newGO);
            return (newGO);
        }
    }

    public GameObject GetObjectForScene(ObjectEnums name)
    {
        if(_objectsPool[name].Count == 0)
        {
            _objectsPool[name].Add(AddNewObject(name));
        }

        if(_objectsPool[name].Count > 0)
        {
            GameObject goForScene = _objectsPool[name][_objectsPool[name].Count - 1];

            _objectsPool[name].RemoveAt(_objectsPool[name].Count - 1);
            return goForScene;
        }

        return null;
    }


    public void ReturnStack(GameObject stack, String name)
    {
        
        stack.SetActive(false);
        _objectsPool[ObjectEnums.BigCube].Add(stack);
        
    }


    public void CheckFallenObjects()
    {

    }
    
}
