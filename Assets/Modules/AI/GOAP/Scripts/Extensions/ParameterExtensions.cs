namespace AI.GOAP
{
    public static class ParameterExtensions
    {
        public static bool Includes(this Parameter[] state1, Parameter[] state2)
        {
            for (int i = 0, count = state2.Length; i < count; i++)
            {
                var field = state2[i];
                if (!state1.Includes(field))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Includes(this Parameter[] it, Parameter parameter)
        {
            var requiredName = parameter.name;
            var requiredValue = parameter.value;

            for (int i = 0, count = it.Length; i < count; i++)
            {
                var otherField = it[i];
                if (otherField.name == requiredName && otherField.value == requiredValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}