using System.Linq;
using HackMan.Scripts.BaseComponents;
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
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            var gridParentGameObject = new GameObject("[GRID]");
            var gridSizeY = Grid.GetLength(0);
            var gridSizeX = Grid.GetLength(1);
            for (var y = 0; y < gridSizeY; y++)
            {
                for (var x = 0; x < gridSizeX; x++)
                {
                    var gridObjectPrefab = BaseGridObjectPrefabs[Grid[y, x]];
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
    }
}