using System;
using System.Collections.Generic;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereEnumerableSimple : FilterWhere {
        private IEnumerable<object> Value { get; set; }
        public FilterWhereEnumerableSimple(Enum field, PredicateCondition oper, IEnumerable<object> value) {
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}.{1} {2} {3} ";
        }
        private string ValueToString() {
            return "(" + String.Join(", ", Value) + ") ";
        }
        public override string TranslateToSql() {
            return String.Format(StringFormat, Field.GetType().DeclaringType.Name, Field, Oper.GetMathOper(),
                ValueToString());
        }
    }
}