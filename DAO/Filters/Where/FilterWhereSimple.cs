using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereBaseSimple : FilterWhereBase {
        private string Value { get; set; }
        public FilterWhereBaseSimple(Enum field, PredicateCondition oper, string value) {
            Field = field;
            Oper = oper;
            Value = value;
            StringFormat = "{0}.{1} {2} '{3}' ";
        }
        private string ValueToString() {
            return Value;
        }
        public override string TranslateToSql() {
            return String.Format(StringFormat, Field.GetType().DeclaringType.Name, Field, Oper.GetMathOper(),
                ValueToString());
        }
    }
}