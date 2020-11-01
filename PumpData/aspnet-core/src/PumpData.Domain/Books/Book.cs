using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace PumpData.Books
{
    public class Book: AggregateRoot<Guid>
    {
        public double Pressure1 { get; set; }    
    }
}
