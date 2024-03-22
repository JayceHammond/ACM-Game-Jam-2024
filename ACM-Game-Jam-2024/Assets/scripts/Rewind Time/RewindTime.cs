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

    private List<RewindData> RewindableObjectsData;
    private List<GameObject> RewindableObjects;

    void Start(){
        assignRewindObjects();
    }

    private void assignRewindObjects(){
        Debug.Log( GameObject.FindGameObjectsWithTag("Rewindable")[0]);
        foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag("Rewindable")){
            RewindableObjects.Add(this.gameObject);
            
        }
    }

    public void RewindAnchor(){
        foreach(GameObject item in RewindableObjects){
            RewindData savedItem = new RewindData
            {
                Position = item.transform.position,
                OldObject = item,
            };

            RewindableObjectsData.Add(savedItem);
        }


    }

    public void Rewind(){
        foreach(RewindData item in RewindableObjectsData){
            foreach(GameObject gameObject in RewindableObjects){
                if(item.OldObject == gameObject){
                    gameObject.transform.position = item.Position;
                }
            }
        }


    }

}
