﻿using System.Numerics;
using Interfaces;
using Map;

namespace ParentObjects
{
    public class GameObjectModel
    {
        private readonly Vector2 _startPosition;
        protected Vector2 Direction;
        protected int _speed { get; private set; }
        public bool IsDie { get; private set; }
        public int Health { get; protected set; }
        public Vector2 CurrentPosition { get; protected set; }
        public Vector2 PreviousPosition { get; protected set; }
        public Action<Vector2, bool> Moved;
        public Action<int> TakingDamage;


        public GameObjectModel(Vector2 startPosition, int speed)
        {
            _startPosition = startPosition;
            _speed = speed;
            Spawn();
        }

        protected void Spawn()
        {
            CurrentPosition = _startPosition;
            Moved?.Invoke(CurrentPosition, false);
        }

        public virtual void Move(IInputSystem inputSystem, MapController symbol)
        {
            while (IsDie == false)
            {
                Thread.Sleep(_speed);
                PreviousPosition = CurrentPosition;
                LookForward(inputSystem.GetDirection(), symbol);
            }
        }

        public void TakeDamage(int damage)
        {
            if (Health <= 0)
            {
                Health = 0;
                IsDie = true;
                return;
            }

            Health -= damage;
            TakingDamage?.Invoke(Health);
        }

        protected virtual void LookForward(Vector2 direction, MapController map)
        {
            Direction = CurrentPosition + direction;

            if (map.GetSymbolMap(Direction) == (char)Symbol.CleanCell)
            {
                SetNewPosition(direction);
            }
            else
            {
                CurrentPosition = PreviousPosition;
                Moved?.Invoke(CurrentPosition, false);
            }
        }

        protected void SetNewPosition(Vector2 direction)
        {
            CurrentPosition += direction;
            Moved?.Invoke(CurrentPosition, true);
        }
    }
}
