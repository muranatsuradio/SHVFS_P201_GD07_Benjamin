using System.Collections.Generic;
using System.Linq;
using HackMan.Scripts.BaseComponents;
using UnityEngine;

namespace HackMan.Scripts.Systems
{
    public class LevelGeneratorSystem : Singleton<LevelGeneratorSystem>
    {
        public BaseGridObject[] BaseGridObjectPrefabs;

        public static LevelGrid CurrentLevel => _currentLevel;
        private static LevelGrid _currentLevel;
        private List<LevelGrid> _levels;
        private GameObject _levelParentGameObject;
        
        #region GridNotes

        // 0: Pill, 1: Wall, 2: HackMan, 3: Ghost.
        // public static int[,] Grid = new int[,]
        // {
        //     {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        //     {1, 2, 0, 0, 0, 0, 0, 0, 0, 3, 1},
        //     {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
        //     {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //     {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
        //     {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        //     {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1},
        //     {1, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1},
        //     {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        // };

        #endregion

        protected override void Awake()
        {
            _levels = AppDataSystem.LoadAll<LevelGrid>();

            Generate();
        }

        public void Generate()
        {
            ClearLevel();
            
            CollectionSystem.Instance.ResetCollectedAmount();
            
            while (true)
            {
                var index = Random.Range(0, _levels.Count);

                if (_currentLevel != null && _currentLevel == _levels[index]) continue;
                
                _currentLevel = _levels[index];
                    
                break;
            }
            
            GenerateLevel(_currentLevel);
        }

        private void ClearLevel()
        {
            if (!_levelParentGameObject)
            {
                _levelParentGameObject = new GameObject("[GRID]");
            }

            if (_levelParentGameObject.transform.childCount == 0) return;

            for (var i = 0; i < _levelParentGameObject.transform.childCount; i++)
            {
                Destroy(_levelParentGameObject.transform.GetChild(i).gameObject);
            }
        }

        private void GenerateLevel(LevelGrid levelGrid)
        {
            
            var gridSizeY = levelGrid.Grid.GetLength(0);
            var gridSizeX = levelGrid.Grid.GetLength(1);
            for (var y = 0; y < gridSizeY; y++)
            {
                for (var x = 0; x < gridSizeX; x++)
                {
                    var gridObjectPrefab = BaseGridObjectPrefabs[levelGrid.Grid[y, x]];
                    var gridObjectClone = Instantiate(gridObjectPrefab);
                    gridObjectClone.transform.parent = _levelParentGameObject.transform;
                    gridObjectClone.GridPosition = new IntVector2(x, -y);
                    gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x,
                        gridObjectClone.GridPosition.y, 0);
                    // -y : Make Template Looks Like Grid[,]
                }
            }
        }

        public int GetCollectionAmount()
        {
            return _currentLevel.Grid.Cast<int>().Count(baseGrid => baseGrid == 0);
        }

        // #region C6
        //
        // [ContextMenu("Log Grid")]
        // private void LogGrid()
        // {
        //     var obj = JsonConvert.SerializeObject(Grid);
        //     Debug.Log(obj);
        // }
        //
        // [ContextMenu("Save Level")]
        // private void SaveLevel()
        // {
        //     var savedGrid = JsonConvert.SerializeObject(Grid);
        //     var fullFilePath = $"{Application.dataPath}/StreamingAssets/Levels/Level_0.json";
        //
        //     if (!File.Exists(fullFilePath))
        //     {
        //         var fileStream = File.Create(fullFilePath);
        //         fileStream.Close();
        //     }
        //
        //     File.WriteAllText(fullFilePath, savedGrid);
        //
        //     Debug.Log($"saved level: {savedGrid}");
        // }
        //
        // #endregion
    }
}