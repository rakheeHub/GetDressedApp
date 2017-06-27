using System;
using System.Collections.Generic;

namespace GetReadyPackage
{
    class HotClimate : IResponse
    {
        private readonly Dictionary<int, string> _commandData;
        public HotClimate(Dictionary<int, string> commandData)
        {
            _commandData = commandData;
        }

        public string GetResponse(int index)
        {
            if (!_commandData.ContainsKey(index) || !IsValidIndex(index))
            {
                return "fail";
            }
            return _commandData[index];
        }

        private bool IsValidIndex(int index)
        {
            if (index == 3 || index == 5)
                return false;
            CommandType command = CommandType.None;

            if (Enum.IsDefined(typeof(CommandType), index))
            {
                command = (CommandType)index;
            }
            return TaskManager.GetInstance().IsTaskDoable(command);
        }
    }
}
