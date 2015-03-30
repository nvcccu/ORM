using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereSimple : FilterWhere {
        private object Value { get; set; }
        public FilterWhereSimple(Enum field, PredicateCondition oper, object value) {
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}.{1} {2} '{3}' ";
        }
        private string ValueToString() {
            return Value.ToString();
        }
        public override string TranslateToSql() {
            return String.Format(StringFormat, Field.GetType().DeclaringType.Name, Field, Oper.GetMathOper(),
                ValueToString());
        }
    }
}