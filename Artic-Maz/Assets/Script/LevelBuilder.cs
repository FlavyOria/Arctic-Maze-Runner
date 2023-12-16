using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


namespace LevelBuilderSystem
{
    namespace LevelBuilderSystem
    {
        public class LevelBuilder : MonoBehaviour
        {
            [SerializeField]
            private GameObject WallPrefab;

            [SerializeField]
            private GameObject IglooPrefab;

            [SerializeField]
            private GameObject emptyPrefab;

            void Start()
            {
                BuildLevel();
            }

            void BuildLevel()
            {
                string sceneName = SceneManager.GetActiveScene().name;

                string filePath = "Assets/Scenes/" + sceneName + ".txt";



                string[] lines = File.ReadAllLines(filePath);

                for (int y = 0; y < lines.Length; y++)
                {
                    string line = lines[y];

                    for (int x = 0; x < line.Length; x++)
                    {
                        char code = line[x];
                        Vector3 position = new Vector3(x, -y, 0);

                        switch (code)
                        {
                            case '#':
                                Instantiate(WallPrefab, position, Quaternion.identity);
                                break;

                            case 'H':
                                Instantiate(IglooPrefab, position, Quaternion.identity);
                                break;

                            case '.':
                                Instantiate(emptyPrefab, position, Quaternion.identity);
                                break;

                            default:
                                Debug.LogWarning("Unknown code in the text file: " + code);
                                break;
                        }
                    }
                }
            }    
    public GameObject WallSprite
    {
        get => WallPrefab;
        set => WallPrefab = value;
    }

    public GameObject IglooSprite
    {
        get => IglooPrefab;
        set => IglooPrefab = value;
    }
    
    }
        
    }
}