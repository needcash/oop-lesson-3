﻿using MadScientistLab.Laboratory.Cli;
using MadScientistLab.Laboratory.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Machines
{
    public class Barker
    {
        private ICommandInterface _cli;

        public Barker(ICommandInterface cli)
        {
            _cli = cli;
        }

        public void Execute(IBarkable animal)
        {
            animal.Bark(_cli);
        }
    }
}
