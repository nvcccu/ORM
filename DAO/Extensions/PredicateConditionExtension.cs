using DAO.Enums;

namespace DAO.Extensions {
    public static class PredicateConditionExtension {
        public static string GetMathOper(this PredicateCondition oper) {
            switch (oper) {
                case PredicateCondition.Equal:
                    return "=";
                case PredicateCondition.Greater:
                    return ">";
                case PredicateCondition.Less:
                    return "<";
                case PredicateCondition.In:
                    return "IN";
                case PredicateCondition.NotIn:
                    return "NOT IN";
                // todo: лень сразу писать все операторы :-)
                default:
                    return null;
            }
        }
    }
}