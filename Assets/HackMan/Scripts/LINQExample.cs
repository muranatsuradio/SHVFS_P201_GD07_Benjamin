using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LINQExample : MonoBehaviour
{
// Language
// INtegrated
// Query

    private void OnEnable()
    {
        var names = new[] {"Gary", "Chloe", "Claire", "Rebecca", "EZ", "Ben", "Kevin", "Giselle"};

        // Query syntax
        var namesWithAQuery = from name in names
            where name.Contains("C")
            select name;

        // Method syntax
        var namesWithAMethod = names.Where(name => name.Contains("C"));

        foreach (var name in namesWithAQuery)
        {
            //Debug.Log($"QUERY: {name}");
        }

        foreach (var name in namesWithAMethod)
        {
            //Debug.Log($"METHOD: {name}");
        }

        // Method syntax has MORE operators and methods, the compiler converts query syntax to method syntax.. It doesn't really matter which one you use

        var enemies = new List<Enemy>()
        {
            new Enemy() {Name = "Gary", HP = 9000},
            new Enemy() {Name = "Ben", HP = 99},          
            new Enemy() {Name = "Chris", HP = 0},
            new Enemy() {Name = "Claire", HP = 1},
            new Enemy() {Name = "Chloe", HP = 2},
            new Enemy() {Name = "Rebecca", HP = 10},
            new Enemy() {Name = "Giselle", HP = 34},
            new Enemy() {Name = "Kevin", HP = 45},
            new Enemy() {Name = "EZ", HP = 50},
        };

        // Filtering operators: filter a sequence based on some argument or criteria
        // Lambda... "=>"  "Goes to"
        var deadEnemies = enemies.Where(enemy => enemy.HP <= 0);

        foreach (var enemy in deadEnemies)
        {
            Debug.Log($"Dead Enemy: {enemy.Name}");
        }
    }

    public class Enemy
    {
        public string Name;
        public int HP;
    }
}