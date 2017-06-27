using System;
using System.Collections.Generic;

namespace GetReadyPackage
{
    class TaskManager
    {
        private readonly Dictionary<int, List<int>> _sequenceTask;
        private readonly List<CommandType> _blockedTasks;
        private static TaskManager _taskManager;
        private List<CommandType> pendingTasks;
        private TaskManager()
        {
            _blockedTasks = new List<CommandType>
            {
                CommandType.Footwear,
                CommandType.Headwear,
                CommandType.Jacket,
                CommandType.LeaveHouse,
                CommandType.Pants,
                CommandType.Shirt,
                CommandType.Socks
            };

            pendingTasks = new List<CommandType>
            {
                CommandType.Footwear,
                CommandType.Headwear,
                CommandType.Jacket,
                CommandType.LeaveHouse,
                CommandType.Pants,
                CommandType.Shirt,
                CommandType.Socks,
                CommandType.TakeOffPajamas
            };
        }

        public static TaskManager GetInstance()
        {
            return _taskManager ?? (_taskManager = new TaskManager());
        }

        public bool IsTaskDoable(CommandType command)
        {
            if (command == CommandType.LeaveHouse)
            {
                return pendingTasks.Count == 1 && pendingTasks.Contains(CommandType.LeaveHouse);

            }
            return !_blockedTasks.Contains(command);
        }

        public void CompleteTask(CommandType command)
        {
            if (IsTaskDoable(command))
                pendingTasks.Remove(command);

            if (!pendingTasks.Contains(CommandType.TakeOffPajamas))
            {
                _blockedTasks.Remove(CommandType.Pants);
                _blockedTasks.Remove(CommandType.Shirt);
                _blockedTasks.Remove(CommandType.Socks);

            }
            if (!pendingTasks.Contains(CommandType.Socks) && !pendingTasks.Contains(CommandType.Pants))
            {
                _blockedTasks.Remove(CommandType.Footwear);
            }
            if (!pendingTasks.Contains(CommandType.Shirt))
            {
                _blockedTasks.Remove(CommandType.Headwear);
                _blockedTasks.Remove(CommandType.Jacket);
            }
        }

        public static List<Tuple<int, string, string>> GetCommandData()
        {
            return new List<Tuple<int, string, string>>
            {
                new Tuple<int, string, string>(1,"sandals","boots"),
                new Tuple<int, string, string>(2,"sun visor","hat"),
                new Tuple<int, string, string>(3,"fail","socks"),
                new Tuple<int, string, string>(4,"t-shirt","shirt"),
                new Tuple<int, string, string>(5,"fail","jacket"),
                new Tuple<int, string, string>(6,"shorts","pants"),
                new Tuple<int, string, string>(7,"leaving house","leaving house"),
                new Tuple<int, string, string>(8,"Removing PJs","Removing PJs")
            };
        }
    }
}
