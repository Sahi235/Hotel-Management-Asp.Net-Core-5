using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ExecutionFlow.RoomTypeExecutors
{
    public class RoomTypesExecutors : IExecutors
    {
        public bool CanBeExecuted()
        {
            return false;
        }

        public void Execute()
        {
        }

        public void Undo()
        {
        }
    }
}
