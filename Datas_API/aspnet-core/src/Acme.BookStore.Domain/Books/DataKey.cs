using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.BookStore.Books
{
    public class DataKey
    {
        protected BsonTimestamp Id { get; set; }
        public double data { get; set; }

        public  DataKey(BsonTimestamp id)
        {
            Id = id;
        }
    }
}
