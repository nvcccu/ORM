using System;
using System.Collections.Generic;
using System.Linq;
using DAO;
using DAO.Attributes;
using DAO.Enums;
using DAO.Filters.Where;

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

//            var where = new FilterWhereCollection(
//                new FilterWhereBase[] {
//                    new FilterWhereSimple(LogicOperator.And, DaoTest.Fields.Id, PredicateCondition.Equal, 38.ToString()),
//                    new FilterWhereSimple(LogicOperator.And, DaoTest.Fields.Id, PredicateCondition.Equal, 1.ToString())
//                },
//                new[] {
//                    new FilterWhereCollection(new FilterWhereBase[] {
//                        new FilterWhereSimple(LogicOperator.And, DaoTest.Fields.Text, PredicateCondition.Equal, 2.ToString()),
//                        new FilterWhereSimple(LogicOperator.And, DaoTest.Fields.ParentId, PredicateCondition.Equal, 3.ToString())
//                    }, null)
//                })
//                .TranslateToSql(true);







            Connector.ConnectionString = "Server=localhost;Port=5432;User=postgres;Password=postgres;Database=postgres;";

            var q = new DaoTest()
                .Select()
                .Where(DaoTest.Fields.Id, PredicateCondition.Greater, 0)
                .Where(DaoTest.Fields.DateCreated, PredicateCondition.Greater, new DateTime(1999, 2, 2))
                .Where(DaoTest.Fields.Text, PredicateCondition.Equal, "text1")
                .Where(new FilterWhereCollection(new FilterWhereBase[] {
                    new FilterWhereDate(LogicOperator.And, DaoTest.Fields.DateCreated, PredicateCondition.Greater,
                        new DateTime(1999, 2, 2)),
                    new FilterWhereDate(LogicOperator.Or, DaoTest.Fields.DateCreated, PredicateCondition.Greater,
                        new DateTime(1999, 2, 2)),
                }, new[] {
                    new FilterWhereCollection(
                        new FilterWhereBase[] {
                            new FilterWhereDate(LogicOperator.And, DaoTest.Fields.DateCreated,
                                PredicateCondition.Greater, new DateTime(1999, 2, 2)),
                            new FilterWhereDate(LogicOperator.Or, DaoTest.Fields.DateCreated, PredicateCondition.Greater,
                                new DateTime(1999, 2, 2)),
                        }, null)
                }))
                .Where(DaoTest.Fields.Text, PredicateCondition.Equal, "text2")
                .GetData()
                .ToList();
         
            var w = 0;
        }
    }
}