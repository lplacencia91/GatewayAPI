using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GatwQueryServices
{
   
    public class GatewayQueryServices: RepositoryBase<Gateway>, IGatewayServices
    {
        private readonly IRepositoryManaguer _repositoryManaguer;
        public GatewayQueryServices(RepositoryContext repositoryContext,IRepositoryManaguer repository)
        : base(repositoryContext)
        {
            _repositoryManaguer=repository;
        }
        //CreateGateway
        public void CreateGateway(Gateway gateway)
        {
                Create(gateway);
                _repositoryManaguer.Save();
        }

        //GetAllGatewayspaging
        public async Task<PageList<Gateway>> GetAll(GatewayParameter gatewayparameter)
        {
            bool trackChanges = false;
            var gateways = await FindAll(trackChanges);
            return  PageList<Gateway>.ToPageList(gateways, gatewayparameter.pageNumber, gatewayparameter.PageSize); ;
        }

        //GetBySerialNumber
        public async Task<Gateway> GetBySerialNumber(Guid serialnumber)
        {
            bool trackChanges = false;
            var gateway = await FindByCondition(x => x.SerialNumber == serialnumber, trackChanges);
            return gateway.FirstOrDefault();
        }

        //DeleteGateway
        public void DeleteGateway(Gateway gateway)
        {
            Delete(gateway);
            _repositoryManaguer.Save();
        }

        //UpdateGateway
        public void UpdateGateway(Gateway gateway)
        {
            Update(gateway);
            _repositoryManaguer.Save();
        }


    }
}
