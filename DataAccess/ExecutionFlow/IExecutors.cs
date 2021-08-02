using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ExecutionFlow
{
    public interface IExecutors
    {
        bool CanBeExecuted();
        void Execute();
        void Undo();
    }
}
