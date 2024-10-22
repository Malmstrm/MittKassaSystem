using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittKassaSystem.ReceiptFolder
{
    public interface IReceiptRepository // används ej ännu
    {
        void SaveRepository(Receipt receipt);
    }
}
