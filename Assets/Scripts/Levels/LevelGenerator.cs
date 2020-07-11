using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public ColorToPrefab[] colorMappings;

    private Dictionary<int, Texture2D> levels = new Dictionary<int, Texture2D>();

    private void Awake() {
        ReadLevels();
    }

    private void ReadLevels() {
        Object[] obj = Resources.LoadAll("Levels", typeof(Texture2D));

        foreach (Object o in obj) {
            if (int.TryParse(o.name, out int num)) {
                levels.Add(num, (Texture2D)o);
            }
        }
    }

    #region Generation
    public void GenerateLevel(int level) {
        if (!levels.ContainsKey(level)) {
            Debug.Log("you win");
            return;
        }

        Texture2D map = levels[level];

        for (int x = 0; x < map.width; x++) {
            for (int y = 0; y < map.height; y++) {
                GenerateTile(x, y, map);
            }
        }
    }

    private void GenerateTile(int x, int y, Texture2D map) {
        Color pixelColor = map.GetPixel(x, y);

        //Transparent pixel
        if (pixelColor.a == 0) {
            return;
        }
        
        foreach (ColorToPrefab colorMapping in colorMappings) {
            if (colorMapping.color.Equals(pixelColor)) {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
    #endregion
}
