using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;


        }
        public Guid Id { get;  set; }

        public DateTime CreationDate { get; set; }

        public string Descriptor { get; set; }


        public bool IsDeleted { get; set; }

        
    }
}
