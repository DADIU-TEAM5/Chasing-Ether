using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{

    public Transform rokokoSkeleton;

    public List<indexedBone> indexedBones;

    public bool done = false;
    // Start is called before the first frame update
    
    public List<Frame> animations = new List<Frame>(); 
    void Start()
    {
        List<Transform> listOfAllBones = new List<Transform>();
        indexedBones = new List<indexedBone>();

        GetAllChildren(rokokoSkeleton, listOfAllBones);

        

        using (var reader = new StreamReader(@"C:\Users\dadiu\Documents\GitHub\MiniGame1_New\Minigame1New\Assets\Animations\StandingIdle_MIXAMO_E46.csv"))
        {

            var nameLine= reader.ReadLine();
            var boneName = nameLine.Split(',');

            for (int i = 0; i < boneName.Length; i++)
            {
                for (int j = 0; j < listOfAllBones.Count; j++)
                {
                   if(boneName[i].Contains(listOfAllBones[j].name))
                    {
                        indexedBone bone = new indexedBone();
                        bone.index = i/7 ;

                        //print("bone with index " + bone.index + " created");
                        bone.bone = listOfAllBones[j];
                        indexedBones.Add(bone);
                    }
                }
            }

            
            print(indexedBones[7].bone.name +" "+indexedBones[7].index);


            while (!reader.EndOfStream)
            {
                Frame temp = new Frame();
                temp.joints = new Joint[26];

                var line = reader.ReadLine();
                var values = line.Split(',');
                float[] floatValues = new float[values.Length];


                // Convesion from string to float
                for (int i = 0; i < values.Length; i++)
                {

                    if (values[i].Contains("."))
                    {
                        int valueLength = values[i].Length;
                        floatValues[i] = float.Parse(values[i]);

                        int start = 0;
                        if (values[i].Contains("-"))
                        {
                            start++;
                        }

                        for (int j = start; j < valueLength - 2; j++)
                        {
                            floatValues[i] *= 0.1f;
                        }

                    }
                    else
                    {
                        floatValues[i] = float.Parse(values[i]);
                    }



                    // Print single frame
                    if (animations.Count == 18)
                        print(values[i] + " , " + floatValues[i]);
                }




                for (int i = 1; i < values.Length - 8; i += 7)
                {
                    for (int j = 0; j < temp.joints.Length; j++)
                    {



                        Vector3 tempvect = new Vector3(floatValues[i], floatValues[i + 1], floatValues[i + 2]);
                        temp.joints[j].position = tempvect;
                        //print("Joint: " + j + " : " + tempvect);

                        Vector4 tempvec4 = new Vector4(floatValues[i + 3], floatValues[i + 4], floatValues[i + 5], floatValues[i + 6]);
                        temp.joints[j].rotation = tempvec4;



                    }

                }

                animations.Add(temp);

            }

            /*
            for (int i = 0; i < animations[1].joints.Length; i++)
            {
                print("Joint: " + i + " = position = " + animations[5].joints[i].position);
                print("Joint: " + i + " rotatation = " + animations[5].joints[i].rotation);

            }
            */
        }


        print("Data Loaded");
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GetAllChildren(Transform parent, List<Transform> childList)
    {
        

        if (parent.childCount > 0)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                childList.Add(parent.GetChild(i));
                GetAllChildren(parent.GetChild(i), childList);
            }
        }
        

    }
}


public struct Joint
{
    public Vector3 position;
    public Vector4 rotation;

}

public struct Frame
{
    public Joint[] joints;
    public int frameNumber;
    public string animationName;


}
public struct indexedBone
{
    public int index;
    public Transform bone;
}

