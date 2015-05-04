using DAO.Enums;

namespace DAO.Extensions {
    public static class PredicateConditionExtension {
        public static string GetMathOper(this PredicateCondition oper) {
            switch (oper) {
                case PredicateCondition.Equal:
                    return " = ";
                case PredicateCondition.NotEqual:
                    return " <> ";
                case PredicateCondition.Greater:
                    return ">";
                case PredicateCondition.GreaterOrEqual:
                    return " >= ";
                case PredicateCondition.Less:
                    return "<";
                case PredicateCondition.LessOrEqual:
                    return " <= ";
                case PredicateCondition.In:
                    return " IN ";
                case PredicateCondition.NotIn:
                    return " NOT IN ";
                case PredicateCondition.Like:
                    return " LIKE ";
                // todo: лень сразу писать все операторы :-)
                default:
                    return null;
            }
        }
    }
}