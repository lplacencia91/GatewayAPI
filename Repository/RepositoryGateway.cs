using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryGateway : RepositoryBase<Gateway>, IGatewayRepository
    {
        public RepositoryGateway(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
