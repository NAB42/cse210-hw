using System.Net.NetworkInformation;

public class Fraction
{
    /* Attributes */
    private int _numerator;
    private int _denominator;

    /* Constructors */
    public Fraction(int num,int denom){
        _numerator=num;
        _denominator=denom;
    }
    public Fraction(int num)
    {
        new Fraction(num,1);
    }
    public Fraction()
    {
        new Fraction(1,2);
    }
    
    /* Methods */
    public int GetNumerator()
    {
        return _numerator;
    }
    public int GetDenominator()
    {
        return _denominator;
    }
    public string ProperFraction()
    {
        if (_numerator < _denominator)
            return $"{_numerator}/{_denominator}";
        else if (_numerator%_denominator == 0)
            return $"{_numerator/_denominator}";
        return $"{_numerator/_denominator} {_numerator%_denominator}/{_denominator}";
    }
    public string ImproperFraction()
    {
        if (_numerator%_denominator == 0)
            return $"{_numerator/_denominator}";
        return $"{_numerator}/{_denominator}";
    }

    public void SetNumerator(int num)
    {
        _numerator=num;
    }
    public void SetDenominator(int denom)
    {
        _denominator=denom;
    }
    public void SetFraction(int num,int denom)
    {
        _numerator=num;
        _denominator=denom;
    }
}