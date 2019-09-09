using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    // Start is called before the first frame update
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

    public List<Frame> animations = new List<Frame>(); 
    void Start()
    {
        using (var reader = new StreamReader(@"C:\Users\dadiu\Documents\DADIU\Git\MiniGame1\MiniGame1\Assets\Animations\SuddenCrouch_DEFAULT_E46.csv"))
        {

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                Frame temp = new Frame();
                temp.joints = new Joint[26];

                var line = reader.ReadLine();
                var values = line.Split(',');

                //print(values.Length);

                //print("values: " + values[14]);

                float j = 0;
                for (int i = 1; i < values.Length;)
                {
                    //print("modulo "+ j % 2);
                    if (i + 4 >= values.Length)
                        break;
                    if((int)j%2 == 1)
                    {
                      //  print(values[i]);
                        Vector3 tempvect = new Vector3(float.Parse(values[i]), float.Parse(values[i+1]), float.Parse(values[i+2]));
                        temp.joints[(int)j].position = tempvect;
                        //print(tempvect + " vector " + i);
                        i += 3;
                    }
                    else
                    {
                        
                        Vector4 tempvect = new Vector4(float.Parse( values[i]), float.Parse(values[i+1]), float.Parse(values[i+2]), float.Parse(values[i+3]));
                        temp.joints[(int)j].rotation = tempvect;
                        i += 4;
                        //print("rotation " + values[i] + "Joint " + j + "frame " + i);
                        
                    }
                    j+=0.5f;

                }

                animations.Add(temp);

            }


            for (int i = 0; i < animations[1].joints.Length; i++)
            {
                print("Joint: " + i + " = position = " + animations[5].joints[i].position);
                print("Joint: " + i + " rotatation = " + animations[5].joints[i].rotation);

            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
