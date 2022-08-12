using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManaguer
    {
        IGatewayRepository Gateway { get; }
        IDeviceRepository Device { get; }
        Task Save();
    }
}
