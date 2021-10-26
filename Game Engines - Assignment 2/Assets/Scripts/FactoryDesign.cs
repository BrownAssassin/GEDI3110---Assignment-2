using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System;

namespace FactoryDesign
{

    public abstract class Fruit
    {
        public abstract string Name { get; }

        public abstract void Process();

    }

    public class Cherry : Fruit
    {
        public override string Name => "Cherry";

        public override void Process()
        {
            //Cherry creation
        }
    }

    public class Strawberry : Fruit
    {
        public override string Name => "Strawberry";

        public override void Process()
        {
            //Strawberry creation
        }
    }

    public class FruitFactory
    {

        private Dictionary<string, Type> FruitsLists;

        public FruitFactory()
        {
            var fruitType = Assembly.GetAssembly(typeof(Fruit)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Fruit)));

            FruitsLists = new Dictionary<string, Type>();

            foreach (var type in fruitType)
            {

                var temp = Activator.CreateInstance(type) as Fruit;
                FruitsLists.Add(temp.Name, type);

            }


        }

        public Fruit GetFruit(string fruitName)
        {
            if (FruitsLists.ContainsKey(fruitName))
            {
                Type type = FruitsLists[fruitName];
                var fruit = Activator.CreateInstance(type) as Fruit;

                return fruit;
            }

            return null;
        }

        internal IEnumerable<string> GetFruitNames()
        {
            return FruitsLists.Keys;
        }
    }
}