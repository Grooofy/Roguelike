﻿using System.Numerics;
using Interfaces;
using Map;
using ParentObjects;

namespace Player
{
    public class PlayerModel : GameObjectModel
    {
        private Pickaxe _pickaxe;

        public Action<int> PickaxeAmountChanged
        {
            get => _pickaxe.AmountChanged;
            set => _pickaxe.AmountChanged = value;
        }

        public PlayerModel(int health, int pickaxeAmount, Vector2 startPosition, int speed) : base(startPosition, speed)
        {
            Health = health;
            _pickaxe = new Pickaxe(pickaxeAmount);
        }

        public override void Move(IInputSystem inputSystem, MapController symbol)
        {
            PreviousPosition = CurrentPosition;
            LookForward(inputSystem.GetDirection(), symbol);
        }

        protected override void LookForward(Vector2 direction, MapController map)
        {
            base.LookForward(direction, map);

            if (map.GetSymbolMap(Direction) == (char)Symbol.Wall && _pickaxe.HitAmount != 0)
            {
                SetNewPosition(direction);
                map.RemoveWall(Direction);
                _pickaxe.RemovePickaxe();
            }
        }
    }
}
