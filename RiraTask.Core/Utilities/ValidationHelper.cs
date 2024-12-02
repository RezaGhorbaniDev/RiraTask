using RiraTask.Core.Exceptions;

namespace RiraTask.Core.Utilities;

public static class ValidationHelper
{
    public static void ValidateNationalId(string nationalId)
    {
        if (string.IsNullOrWhiteSpace(nationalId) || !IsValid(nationalId))
        {
            throw new BadRequestException("Invalid national id.");
        }
    }

    /// <summary>
    /// Validates persian national id
    /// [Source: https://stackoverflow.com/questions/68150111/how-to-validate-national-identity-shenaseh-meli-of-iranian-legal-people] 
    /// </summary>
    private static bool IsValid(string nationalNo)
    {
        int[] mult = { 29, 27, 23, 19, 17, 29, 27, 23, 19, 17 };
        int length = nationalNo.Length;

        if (nationalNo.All(char.IsDigit) && length == 11)
        {
            char[] chars = nationalNo.ToCharArray();
            int checkDigit = chars[length - 1] - '0';
            int delta = 0;
            int tensPlusTwo = chars[length - 2] - '0' + 2;

            for (int i = 0; i < length - 1; i++)
            {
                delta += ((chars[i] - '0' + tensPlusTwo) * mult[i]);
            }

            int remain = delta % 11;
            remain = remain == 10 ? 0 : remain;
            return remain == checkDigit;
        }

        return false;
    }
}