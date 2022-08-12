using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManaguer: IRepositoryManaguer
    {
    private RepositoryContext _repositoryContext;
    private IGatewayRepository _gatewayRepository;
    private IDeviceRepository _deviceRepository;
    public RepositoryManaguer(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    public IGatewayRepository Gateway
    {
        get
        {
            if (_gatewayRepository == null)
                    _gatewayRepository = new RepositoryGateway(_repositoryContext);
            return _gatewayRepository;
        }
    }
    public IDeviceRepository Device
    {
        get
        {
            if (_deviceRepository == null)
                    _deviceRepository = new RepositoryDevice(_repositoryContext);
            return _deviceRepository;
        }
    }
    public Task Save() => _repositoryContext.SaveChangesAsync();
}
    
}
