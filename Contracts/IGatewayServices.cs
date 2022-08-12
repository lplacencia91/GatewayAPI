using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGatewayServices
    {
        void CreateGateway(Gateway gateway);
        Task<PageList<Gateway>> GetAll(GatewayParameter gatewayparameter);
        Task<Gateway> GetBySerialNumber(Guid Id);
        public void DeleteGateway(Gateway gateway);
        void UpdateGateway(Gateway gateway);
    }
}
