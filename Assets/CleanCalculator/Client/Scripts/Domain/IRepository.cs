using System.Collections.Generic;
using Domain.Operation;

namespace Domain
{
    public interface IRepository : IService
    {
        public void SaveOperationsHistory<TOperand, TResult>(List<ICalculatorOperation<TOperand, TResult>> data);
        public List<TOperations> LoadOperationHistory<TOperations>();
        public string LoadUnfinishedOperation();
    }
}