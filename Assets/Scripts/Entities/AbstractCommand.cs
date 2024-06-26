#nullable enable


using System.Collections.Generic;
using CodingStrategy.Entities.Robot;
using CodingStrategy.Entities.Runtime;

namespace CodingStrategy.Entities
{
    /// <summary>
    /// 명령어 구현을 위한 보조 클래스입니다. Invoke, Revoke, Copy 메서드를 구현하여 
    /// 명령어를 구현할 수 있습니다.
    /// </summary>
    public abstract class AbstractCommand : ICommand
    {
        private string _id;

        private readonly ICommandInfo _info;

        /// <summary>
        /// 기본적인 명령어 정보를 생성합니다.
        /// </summary>
        /// <param name="id">명령어의 ID입니다.</param>
        /// <param name="name">명령어의 이름입니다.</param>
        /// <param name="enhancedLevel">명령어의 강화 단계입니다.</param>
        protected AbstractCommand(string id, string name, int enhancedLevel, int grade)
        {
            _id = id;
            _info = new CommandInfoImpl(name, enhancedLevel, grade);
        }

        public virtual string Id
        {
            get => _id;
            set => _id = value;
        }

        public virtual ICommandInfo Info => _info;

        public abstract bool Invoke(params object[] args);

        public abstract bool Revoke(params object[] args);

        public abstract IList<IStatement> GetCommandStatements(IRobotDelegate robot);

        public abstract ICommand Copy(bool keepStatus = true);
    }
}
