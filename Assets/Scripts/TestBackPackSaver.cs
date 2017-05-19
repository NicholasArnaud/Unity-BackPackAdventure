using UnityEngine;

public class TestBackPackSaver : MonoBehaviour
{
    public Backpack backpack;
    public string fileName = "default-backpack";
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.P))
	    {
            UnityEngine.Assertions.Assert.IsNotNull(backpack, "please assign a backpack");
	        BackPackSaver.Instance.SaveBackPack(backpack, fileName);
        }
	        
	}
}
