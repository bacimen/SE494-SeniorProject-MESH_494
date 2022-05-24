using System.Collections;
using System.Collections.Generic;
using System.IO;
using UMA.CharacterSystem;
using UnityEngine;
using UnityEngine.UI;

public class AvatarScene : MonoBehaviour
{
    GameObject umaGO;
    // nextButtonGO saves UMA preset file to local directory...
    GameObject nextButtonGO;

    private void Start()
    {
        CreateSystemDirectories();
        umaGO = GameObject.Find("UMADynamicCharacterAvatar");
        nextButtonGO = GameObject.Find("NextButton");
        nextButtonGO.GetComponent<Button>().onClick.AddListener(() => { SaveAvatar(); });
    }

    private void SaveAvatar()
    {
        umaGO.GetComponent<DynamicCharacterAvatar>().DoSave(filePath: Application.persistentDataPath + "/CharacterRecipes/PlayerAvatar.txt");
    }

    IEnumerator LoadAvatar()
    {
        umaGO.GetComponent<DynamicCharacterAvatar>().SetLoadFilename(filename: "1", DynamicCharacterAvatar.loadPathTypes.Resources);
        yield return new WaitForEndOfFrame();
        umaGO.GetComponent<DynamicCharacterAvatar>().DoLoad();
    }

    private void CreateSystemDirectories()
    {
        if(!Directory.Exists(Application.persistentDataPath + "/CharacterRecipes"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/CharacterRecipes");
        }
    }
}
