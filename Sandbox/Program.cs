using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using DAO.Attributes;
using DAO.Enums;

namespace Sandbox {
    public class DaoTest : AbstractEntity<DaoTest> {
        public DaoTest() : base("DaoTest") {}

        public enum Fields {
            [DbType(typeof (Int64))] Id,
            [DbType(typeof (Int32))] ParentId,
            [DbType(typeof (String))] Text,
            [DbType(typeof (DateTime))] DateCreated
        }

        public long Id { get; set; }
        public string Text { get; set; }
        public int ParentId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class OfferCategory : AbstractEntity<OfferCategory> {
        public OfferCategory() : base("OfferCategory") {}

        public enum Fields {
            [DbType(typeof (Int64))] Id,
            [DbType(typeof (Int64))] ParentId,
        }

        
        public long ParentId { get; set; }
        public long Id { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
            Connector.ConnectionString = "Server=localhost;Port=5432;User=postgres;Password=postgres;Database=postgres;";

            var q = new DaoTest()
                .Select()
                .Where(DaoTest.Fields.Id, PredicateCondition.Greater, 0)
                .Where(DaoTest.Fields.DateCreated, PredicateCondition.Greater, new DateTime(1999, 2, 2))
                .Where(DaoTest.Fields.Text, PredicateCondition.Equal, "text1")
                .GetData()
                .ToList();
         
            var w = 0;
        }
    }
}