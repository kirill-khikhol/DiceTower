using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(Walls))]
public class WallsEditor :Editor {

    public override void OnInspectorGUI() {
        Walls myTarget = (Walls)target;
        float r = myTarget.Radius;
        float h = 20f;
        float angle = 45;
        List<Transform> wallsList = myTarget.WallsList;
        float sqrt2R = Mathf.Sqrt(2*r);
        //for(int i = 0; i<4; i++) {
        //    for(int j = 0; j<4; j++) {
        //        wallsList[i + j].transform.position = new Vector3();
        //    }
        //}
        wallsList[0].localPosition = new Vector3(r, h, 0);
        wallsList[1].localPosition = new Vector3(sqrt2R, h, sqrt2R);
        wallsList[2].localPosition = new Vector3(0, h, r);
        wallsList[3].localPosition = new Vector3(sqrt2R, h, -sqrt2R);
        wallsList[4].localPosition = new Vector3(-r, h, 0);
        wallsList[5].localPosition = new Vector3(-sqrt2R, h, -sqrt2R);
        wallsList[6].localPosition = new Vector3(0, h, -r);
        wallsList[7].localPosition = new Vector3(-sqrt2R, h, sqrt2R);
        for(int i=0;i<wallsList.Count;i++) {
            wallsList[i].Rotate(new Vector3(0, i*angle, 0));
        }


    }


}
