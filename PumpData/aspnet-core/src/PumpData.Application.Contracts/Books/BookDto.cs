using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PumpData.Books
{
    public class BookDto: EntityDto<Guid>
    {
        
        public double Pressure1 { get; set; }
        
    }
}
