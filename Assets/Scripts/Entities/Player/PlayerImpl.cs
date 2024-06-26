namespace CodingStrategy.Entities.Player
{
    using System;
    using Robot;

    [Obsolete("Deprecated", true)]
    public class PlayerImpl : IPlayer
    {
        private readonly string _id;
        private readonly IPlayerDelegate _playerDelegate;
        private readonly IRobotDelegate _robot;
        private readonly IAlgorithm _algorithm;

        public PlayerImpl(string id, IPlayerDelegate playerDelegate, IRobotDelegate robot, IAlgorithm algorithm)
        {
            _id = id;
            _playerDelegate = playerDelegate;
            _robot = robot;
            _algorithm = algorithm;
        }

        public string Id => _id;
        public int HealthPoint => _playerDelegate.HealthPoint;
        public int Level => _playerDelegate.Level;
        public int Exp => _playerDelegate.Exp;
        public int Currency => _playerDelegate.Currency;
        public IRobotDelegate Robot => _robot;
        public IAlgorithm Algorithm => _algorithm;
    }
}
