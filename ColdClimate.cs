using System.Collections.Generic;

namespace GetReadyPackage
{
    class ColdClimate : IResponse
    {
        private readonly Dictionary<int, string> _commandData;
        public ColdClimate(Dictionary<int, string> commandData)
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
            return TaskManager.GetInstance().IsTaskDoable((CommandType)index);
        }
    }
}
