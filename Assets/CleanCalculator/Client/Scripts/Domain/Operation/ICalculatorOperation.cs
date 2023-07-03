using System.Collections.Generic;

namespace Domain.Operation 
{
    public interface ICalculatorOperation<TOperand, TResult>
    {
        public List<TOperand> Operands { get; }
        public TResult Calculate();
    }
}