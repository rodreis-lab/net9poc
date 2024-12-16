using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Contracts
{
    public interface IHasId
    {
        public Guid Id { get; }
    }
}
