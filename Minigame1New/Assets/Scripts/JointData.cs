using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointData : MonoBehaviour
{

    public CSVReader data;
    //public Transform[] joints = new Transform[26];


    List<Frame> animations;

    List<indexedBone> idxBones;

    public int FrameRate = 4;
    public bool interpolate = true;


    int clipLength;

    float currentFrame = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    bool init = true;

    // Update is called once per frame
    void Update()
    {
        if (data.done)
        {
            if (init)
            {
                animations = data.animations;

                idxBones = data.indexedBones;
                init = false;



                clipLength = animations.Count;
                print("we got " + idxBones.Count + " bones");


                getBoneWithIndex(50).rotation = Quaternion.Euler(new Vector3(90, 0, 0));

                
            }
            //print((int)currentFrame);
            PlayAnimation();

        }
    }




    void PlayAnimation()
    {

        currentFrame = (currentFrame + FrameRate * Time.deltaTime)% clipLength;

        
        if (interpolate)
        {
           
            //ShoulderJoint.localRotation = Quaternion.Lerp(Quaternion.Euler(shoulderJointPos[(int)currentFrame]), Quaternion.Euler(shoulderJointPos[((int)currentFrame + 1) % clipLength]), currentFrame - (int)currentFrame);

        }
        else
        {

            //print("We got here");
            for (int i = 0; i < animations[(int)currentFrame].joints.Length; i++)
            {
               getBoneWithIndex(i).rotation =vec4ToQuaternion( animations[(int)currentFrame].joints[i].rotation);
               // getBoneWithIndex(i).position = animations[50].joints[i].position;

            }
            
        }
        

    }

    Quaternion vec4ToQuaternion(Vector4 vec)
    {
        print(vec);
        Quaternion qt = new Quaternion(vec.x, vec.y, vec.z, vec.w);
        return qt;
    }

    Transform getBoneWithIndex(int idx)
    {
        Transform tf;
        for (int i = 0; i < idxBones.Count; i++)
        {
            if (idxBones[i].index == idx) {
                tf = idxBones[i].bone;
                return tf;
                    }
        }

        Debug.LogError("no bone with index "+idx+" found");
        return transform;
    }
}
