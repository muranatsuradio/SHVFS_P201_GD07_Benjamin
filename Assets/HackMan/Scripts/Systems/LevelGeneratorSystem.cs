using System.IO;
using System.Linq;
using HackMan.Scripts.BaseComponents;
using Newtonsoft.Json;
using UnityEngine;

namespace HackMan.Scripts.Systems
{
    public class LevelGeneratorSystem : Singleton<LevelGeneratorSystem>
    {
        public BaseGridObject[] BaseGridObjectPrefabs;

        // 0: Pill, 1: Wall, 2: HackMan, 3: Ghost.
        public static int[,] Grid = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 2, 1, 0, 0, 1, 0, 0, 0, 1},
            {1, 0, 1, 1, 0, 0, 0, 1, 3, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 3, 1},
            {1, 0, 1, 1, 0, 1, 0, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        };

        protected override void Awake()
        {
            AppDataSystem.Save(new LevelGrid(Grid), "Level0");

            var level0 = AppDataSystem.Load<LevelGrid>("Level0");
            
            GenerateLevel(level0);
        }

        private void GenerateLevel(LevelGrid levelGrid)
        {
            var gridParentGameObject = new GameObject("[GRID]");
            var gridSizeY = levelGrid.Grid.GetLength(0);
            var gridSizeX = levelGrid.Grid.GetLength(1);
            for (var y = 0; y < gridSizeY; y++)
            {
                for (var x = 0; x < gridSizeX; x++)
                {
                    var gridObjectPrefab = BaseGridObjectPrefabs[levelGrid.Grid[y, x]];
                    var gridObjectClone = Instantiate(gridObjectPrefab);
                    gridObjectClone.transform.parent = gridParentGameObject.transform;
                    gridObjectClone.GridPosition = new IntVector2(x, -y);
                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x,
                        gridObjectClone.GridPosition.y, 0);
                    // -y : Make Template Looks Like Grid[,]
                }
            }
        }

        public int GetCollectionAmount()
        {
            return Grid.Cast<int>().Count(baseGrid => baseGrid == 0);
        }

        #region C6

        [ContextMenu("Log Grid")]
        private void LogGrid()
        {
            var obj = JsonConvert.SerializeObject(Grid);
            Debug.Log(obj);
        }

        [ContextMenu("Save Level")]
        private void SaveLevel()
        {
            var savedGrid = JsonConvert.SerializeObject(Grid);
            var fullFilePath = $"{Application.dataPath}/StreamingAssets/Levels/Level_0.json";

            if (!File.Exists(fullFilePath))
            {
                var fileStream = File.Create(fullFilePath);
                fileStream.Close();
            }

            File.WriteAllText(fullFilePath, savedGrid);

            Debug.Log($"saved level: {savedGrid}");
        }

        #endregion
    }
}