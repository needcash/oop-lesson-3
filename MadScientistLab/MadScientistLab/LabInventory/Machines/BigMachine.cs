﻿using MadScientistLab.Cli;
using MadScientistLab.Configuration;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Machines.Strategies;
using MadScientistLab.Validators;

namespace MadScientistLab.LabInventory.Machines
{
    public class BigMachine
    {
        private readonly ICommandInterface _cli;
        private ISoundStrategy _soundStrategy;
        private readonly IAnimalValidator _validator;
        private readonly StrategyMaker _strategyMaker;

        public BigMachine(ICommandInterface cli, IAnimalValidator validator)
        {
            _cli = cli;
            _validator = validator;
            _strategyMaker = new StrategyMaker(_cli);
        }

        public void MakeNoise(Animal animal)
        {
            if (!_validator.ValidateIfAnimalReadyForMachine(animal))
            {
                return;
            }

            ChangeStrategy(animal);
            _soundStrategy.MakeNoise(animal);
            animal.Fed = false;
            animal.Rested = false;
        }

        private void ChangeStrategy(Animal animal)
        {
            _soundStrategy = _strategyMaker.CreateStrategyFor(animal);
        }
    }
}
