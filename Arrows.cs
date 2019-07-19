using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Arrows : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     
    void Quit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }

    GameObject clickedGameObject;
    public List<GameObject> Clicked = new List<GameObject>();
    int count = 0;
    float x = -4.5f;

    // Update is called once per frame
    void Update(){
    

    
        if (Input.GetMouseButtonDown(0)) {
 
            clickedGameObject = null;
            //int count = 0;
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
 
            if (hit2d) {
                clickedGameObject = hit2d.transform.gameObject;
                
                count += 1;
                if (count == 1){
                    if (clickedGameObject.name == "Up"){
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.5f, 10f), Quaternion.identity) as GameObject;  
                    } else if (clickedGameObject.name == "Right") {
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.25f, 10f), transform.rotation * Quaternion.Euler (0f, 0f, 30f)) as GameObject;  
                    } else if (clickedGameObject.name == "Left") {
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.25f, 10f), transform.rotation * Quaternion.Euler (0f, 0f, 210f)) as GameObject;  
                    }
                   
                } else { 
                    x += 2;
                    if (clickedGameObject.name == "Up"){
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.5f, 10f), Quaternion.identity) as GameObject;  
                    } else if (clickedGameObject.name == "Right") {
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.25f, 10f), transform.rotation * Quaternion.Euler (0f, 0f, 30f)) as GameObject;  
                    } else if (clickedGameObject.name == "Left") {
                        GameObject copy = Object.Instantiate(clickedGameObject, new Vector3(x, -2.25f, 10f), transform.rotation * Quaternion.Euler (0f, 0f, 210f)) as GameObject;  
                    }
                    
                }
    
               
            }

           
            if (clickedGameObject.name != "Stop"){
            Clicked.Add(clickedGameObject);
            } else {
                for(int i = 0; i < Clicked.Count; i++){
                    Debug.Log(Clicked[i]);
                }
            
            Debug.Log(Clicked.Count);
            //Quit();
            
            }
        }
 
    }
/* 
//Turn Data into RTF file
    public void SaveFile (string path);

    public void SaveMyFile(){
   // Create a SaveFileDialog to request a path and file name to save to.
   SaveFileDialog saveFile1 = new SaveFileDialog();

   // Initialize the SaveFileDialog to specify the RTF extention for the file.
   saveFile1.DefaultExt = "*.rtf";
   saveFile1.Filter = "RTF Files|*.rtf";

   // Determine whether the user selected a file name from the saveFileDialog.
   if(saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
      saveFile1.FileName.Length > 0) 
   {
      // Save the contents of the RichTextBox into the file.
      richTextBox1.SaveFile(saveFile1.FileName);
   }
}
*/
}    
    
            
        
        
    

