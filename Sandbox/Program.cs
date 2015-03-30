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
        public long ParentId { get; set; }
    }

    internal class Program {
        private static void Main(string[] args) {
            Connector.ConnectionString = "Server=localhost;Port=5432;User=postgres;Password=postgres;Database=postgres;";

            var q = new DaoTest()
                .Select()
                .Where(DaoTest.Fields.Id, PredicateCondition.Greater, 0)
                .Where(DaoTest.Fields.ParentId, PredicateCondition.In, new List<int> {2, 18})
//                .Where(DaoTest.Fields.DateCreated, PredicateCondition.In, new List<DateTime> {new DateTime(2015, 3, 30, 21, 41, 24)})
                .Where(DaoTest.Fields.DateCreated, PredicateCondition.Less, new List<DateTime> {DateTime.Now})
                .GetData()
                .ToList();
            var w = 0;
        }
    }
}