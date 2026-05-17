/* 2025.05.16 Nathan Boulton
 * I'm too lazy to comment this more than I have. It's super simple.
 */
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
    public Fraction()
    {
        _numerator=1;
        _denominator=2;
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

    // If it's an improper fraction it will put the whole number in front.
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
    public double GetDecimal()
    {
        return (double)_numerator/(double)_denominator;
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