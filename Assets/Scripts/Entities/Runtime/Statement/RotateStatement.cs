#nullable enable


namespace CodingStrategy.Entities.Runtime.Statement
{
    using System;
    using Robot;

    public class RotateStatement : IStatement
    {
        private readonly IRobotDelegate _robotDelegate;
        private readonly int _direction;

        public RotateStatement(IRobotDelegate robotDelegate, int direction)
        {
            if (direction != 1 && direction != -1)
            {
                throw new ArgumentException();
            }

            _robotDelegate = robotDelegate;
            _direction = direction;
        }

        public void Execute()
        {
            _robotDelegate.Rotate(_direction);
        }

        public StatementPhase Phase => StatementPhase.Move;

        public IStatement Reverse => new RotateStatement(_robotDelegate, -_direction);
    }
}
