using System;
using DAO.Enums;
using DAO.Extensions;

namespace DAO.Filters.Where {
    public class FilterWhereBaseSimple : FilterWhereBase {
        private object Value { get; set; }
        public FilterWhereBaseSimple(Enum field, PredicateCondition oper, object value) {
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