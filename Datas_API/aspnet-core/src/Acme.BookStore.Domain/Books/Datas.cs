using System;
using Volo.Abp.Domain.Entities;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Books
{
    public class Datas : AggregateRoot<BsonTimestamp>
    {
        public override BsonTimestamp Id { get; protected set; }
        public double datas { get; set; }

        public Datas(BsonTimestamp id)
        {
            Id = id;
        }
        public Datas()
        {

        }
    }
}
