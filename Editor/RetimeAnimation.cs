using System;
using System.Diagnostics;
using Newtonsoft.Json;
using UnityEditor;

namespace Giezi.Tools
{
    
    [Serializable]
    public class mydata
    {
        public string tag;
        public float[] times;

        public mydata()
        {
            this.tag = "test";
            this.times = new []{0.1f,0.2f};
        }
    }
    
    public class RetimeAnimation
    {
        
        [MenuItem("Tools/GieziTools/AsepriteAnimationRetimer %k")]
        public static void Retime()
        {
            
            // string _cmd = "\"\"C:\\Program Files (x86)\\Aseprite\\Aseprite.exe\" -script-param file=\"C:\\Users\\bobgi\\Documents\\UnityProjects\\AsepriteAnimationRetimer\\Assets\\Editor\\Slug_red.aseprite\" -script-param jsondata=\"[{\\\"tag\\\":\\\"test\\\",\\\"times\\\":[0.1, 0.2]}]\" -script \"C:\\Users\\bobgi\\Documents\\UnityProjects\\AsepriteAnimationRetimer\\Assets\\Editor\\changeFrameDuration.lua\"\"";

            mydata[] datas = new mydata[1] {new mydata()};

            string message = JsonConvert.SerializeObject(datas);

            string _cmd = "\"\"C:\\Program Files (x86)\\Aseprite\\Aseprite.exe\" -script-param file=\"C:\\Users\\bobgi\\Documents\\UnityProjects\\AsepriteAnimationRetimer\\Assets\\Editor\\testFIle.aseprite\" -script-param jsondata=\"" + message.Replace("\"", "\\\"") + "\" -script \"C:\\Users\\bobgi\\Documents\\UnityProjects\\AsepriteAnimationRetimer\\Assets\\Editor\\changeFrameDuration.lua\"\"";



            UnityEngine.Debug.Log(_cmd);
            
            try
            {
                Process myProcess = new Process();
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                myProcess.StartInfo.CreateNoWindow = false;
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.Arguments = "/k " + _cmd;
                myProcess.EnableRaisingEvents = true;
                myProcess.Start();
                // myProcess.WaitForExit();
            }
            catch (Exception e)
            {
                UnityEngine.Debug.Log(e);
            }
        }
    }
}