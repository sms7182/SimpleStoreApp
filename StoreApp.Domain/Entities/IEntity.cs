using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreationDate { get; set; }
        string Descriptor { get; set; }
        bool IsDeleted { get; set; }
    }

}
