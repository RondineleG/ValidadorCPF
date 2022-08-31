using System.Text.RegularExpressions;

public class CPFValidator
{
    const int FACTOR_DIGIT_1 = 10;
    const int FACTOR_DIGIT_2 = 11;
    const int MAX_DIGITS_1 = 9;
    const int MAX_DIGITS_2 = 10;
    public string CPF { get; set; }

    public CPFValidator(string cpf) => CPF = cpf;
    public bool IsValid()
    {
        if (string.IsNullOrEmpty(CPF)) return false;
        ExtractDigits(CPF);
        if (InvalidLenght()) return false;
        if (IsBLocked()) return false;
        int digit1 = CalculateDigit(FACTOR_DIGIT_1, MAX_DIGITS_1);
        int digit2 = CalculateDigit(FACTOR_DIGIT_2, MAX_DIGITS_2);
        string checkerDigit = ExtractCheckerDigit();
        string calculatedDigit = $"{digit1}{digit2}";
        return checkerDigit == calculatedDigit;

    }
    private void ExtractDigits(string cpf) => CPF = Regex.Replace(cpf, @"[^\d]", string.Empty);

    private bool InvalidLenght() => CPF.Length != 11;

    private bool IsBLocked()
    {
        var inscricaoArray = CPF.ToArray();
        return inscricaoArray.All(x => x == inscricaoArray[0]);
    }

    private int CalculateDigit(int factor, int max)
    {
        var total = 0;
        List<char> list = CPF.ToList().GetRange(0, max);
        for (int i = 0; i < list.Count; i++)
        {
            char item = list[i];
            total += Convert.ToInt32(char.GetNumericValue(item)) * factor--;
        }
        return (total % 11 < 2) ? 0 : (11 - total % 11);;
    }

    private string ExtractCheckerDigit() => CPF.Substring(9, 2);

}