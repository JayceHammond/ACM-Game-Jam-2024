using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RewindTime : MonoBehaviour
{
    public class RewindData {
        public Vector3 Position;
        public GameObject OldObject;
    }

    //public List<RewindData> RewindableObjectsData;
    public List<GameObject> RewindableObjects;

    //Stack of Anchors
    public Stack TimeStack;

    void Start(){
        TimeStack = new Stack();
        assignRewindObjects();
    }

    private void assignRewindObjects(){
        //Debug.Log( GameObject.FindGameObjectsWithTag("Rewindable")[0]);
        foreach(GameObject gameitem in GameObject.FindGameObjectsWithTag("Rewindable")){
            RewindableObjects.Add(gameitem);
            //Debug.Log(RewindableObjects[0]);
        }
    }

    public void RewindAnchor(){
        List<RewindData> RewindableObjectsData = new List<RewindData>();

        foreach(GameObject item in RewindableObjects){

            RewindData savedItem = new RewindData
            {
                Position = item.transform.position,
                OldObject = item,
            };
            Debug.Log(RewindableObjectsData);
            RewindableObjectsData.Add(savedItem);
        }

        if(TimeStack.Count < 3){
            TimeStack.Push(RewindableObjectsData);
        }else{
            Debug.Log("Too Many Anchors");
            TimeStack.Pop();
            TimeStack.Push(RewindableObjectsData);
        }
        
    }

    public void Rewind(){
        List<RewindData> RewindableObjectsData = (List<RewindData>)TimeStack.Pop();
        foreach(RewindData item in RewindableObjectsData){
            foreach(GameObject gameObject in RewindableObjects){
                if(item.OldObject == gameObject){
                    gameObject.transform.position = item.Position;
                }
            }
        }


    }

}
