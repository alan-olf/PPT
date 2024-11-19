using PPT.App.Core.Exceptions;

namespace PPT.App.Core.GuardClause
{
     public static class GuardClauseExtensions
    {

        public static string NullOrEmpty(this IGuardClause clause, string input, string message)
        {

            if (string.IsNullOrEmpty(input))
            {
                throw new BadRequestException(message);
            }

            return input;
        }

        public static T AgainstExpression<T>(this IGuardClause clause, Func<T, bool> func, T input, string message) where T : struct
        {

            if (!func(input))
            {
                throw new BadRequestException(message);
            }

            return input;
        }

        public static T Null<T>(this IGuardClause clause, T input, string message)
        {
            if (input is null)
            {
                throw new BadRequestException(message);
            }
            return input;
        }

    }

}
