using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Operation
{
    public partial class IntegerAdditionOperation : ICalculatorOperation<int, int>
    {
        public IntegerAdditionOperation(List<int> operands) => 
            Operands = operands;
        
        public List<int> Operands { get; private set; }

        public int Calculate() => 
            Operands.Sum();
    }
}