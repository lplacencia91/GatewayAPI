using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryDevice : RepositoryBase<Device>, IDeviceRepository
    {
        public RepositoryDevice(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
