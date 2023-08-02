using Dummiesman;
using System.IO;
using System.Text;
using UnityEngine;

public class ObjFromStream : MonoBehaviour {
	void Start () {
        //make www
        var www = new WWW("http://83.171.249.207/api/v1/hold/image/7af5679e-12f7-4a39-b0a6-2e001b7291d5.obj");
        while (!www.isDone)
            System.Threading.Thread.Sleep(1);
        
        //create stream and load
        var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.text));
        var loadedObj = new OBJLoader().Load(textStream);
	}
}
