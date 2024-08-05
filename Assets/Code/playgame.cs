using UnityEngine;
using UnityEngine.SceneManagement;


public class playgame : MonoBehaviour
{
 public string store;
public string settings;
public string backsc;
private int tim = UIManager.instance.heart;
void Start()
{
 UIManager.instance.SetHeart(tim);
}
public void newgame()
{
 if (tim > 0)
 {
 SceneManager.LoadScene(1);
 }
 else
 {
 Debug.Log("Ko du tim");
 Destroy(gameObject);
 }
}
public void Store()
{ 
SceneManager.LoadScene(store);
}
public void setting()
{
 SceneManager.LoadScene(settings);
}
public void back()
{
 SceneManager.LoadScene(backsc);
}
}

