﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class AdvancedEngine : Engine
    {
        public AdvancedEngine()
            : base()
        {
        }

        protected override void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "wolf":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Wolf(name, position));
                        break;
                    }
                case "lion":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Lion(name, position));
                        break;
                    }
                case "grass":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Grass(position));
                        break;
                    }
                case "boar":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Boar(name, position));
                        break;
                    }
                case "zombie":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Zombie(name, position));
                        break;
                    }
                default:
                    base.ExecuteBirthCommand(commandWords);
                    break;
            }
        }
    }
}
