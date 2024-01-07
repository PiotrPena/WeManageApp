public class Money
{
    public decimal Value { get; private set; }
    public string Currency { get; private set; }

    // Static dictionary to hold conversion rates to USD
    private static Dictionary<string, decimal> conversionRates = new Dictionary<string, decimal>
    {
        { "USD", 1m },
        { "EUR", 1.13m }, // Example rate: 1 EUR = 1.13 USD
        { "GBP", 1.35m }, // Example rate: 1 GBP = 1.35 USD
    };

    public Money(decimal value, string currency)
    {
        if (!conversionRates.ContainsKey(currency))
        {
            throw new ArgumentException($"Unsupported currency: {currency}");
        }

        Value = value;
        Currency = currency;
    }

    public Money ConvertTo(string targetCurrency)
    {
        if (!conversionRates.ContainsKey(targetCurrency))
        {
            throw new ArgumentException($"Unsupported currency: {targetCurrency}");
        }

        decimal conversionRate = conversionRates[Currency] / conversionRates[targetCurrency];
        decimal convertedValue = Value * conversionRate;
        return new Money(convertedValue, targetCurrency);
    }

    public static void UpdateConversionRate(string currency, decimal rate)
    {
        if (!conversionRates.ContainsKey(currency))
        {
            throw new ArgumentException($"Unsupported currency: {currency}");
        }

        conversionRates[currency] = rate;
    }

    public override string ToString()
    {
        return $"{Value} {Currency}";
    }

    public static Money operator +(Money a, Money b)
    {
        // Convert b to the currency of a, then add the values
        Money convertedB = b.ConvertTo(a.Currency);
        return new Money(a.Value + convertedB.Value, a.Currency);
    }

    // Subtraction operator
    public static Money operator -(Money a, Money b)
    {
        // Convert b to the currency of a, then subtract the values
        Money convertedB = b.ConvertTo(a.Currency);
        return new Money(a.Value - convertedB.Value, a.Currency);
    }

    // Multiplication by scalar
    public static Money operator *(Money a, decimal multiplier)
    {
        // Multiply the value by the multiplier
        return new Money(a.Value * multiplier, a.Currency);
    }

    // You might also want to implement the reverse multiplication
    public static Money operator *(decimal multiplier, Money a)
    {
        return a * multiplier;
    }

     // Equality operator
    public static bool operator ==(Money a, Money b)
    {
        if (ReferenceEquals(a, null))
            return ReferenceEquals(b, null);

        if (ReferenceEquals(b, null))
            return false;

        Money convertedB = b.ConvertTo(a.Currency);
        return a.Value == convertedB.Value;
    }

    // Inequality operator
    public static bool operator !=(Money a, Money b)
    {
        return !(a == b);
    }

    // Greater than operator
    public static bool operator >(Money a, Money b)
    {
        Money convertedB = b.ConvertTo(a.Currency);
        return a.Value > convertedB.Value;
    }

    // Less than operator
    public static bool operator <(Money a, Money b)
    {
        Money convertedB = b.ConvertTo(a.Currency);
        return a.Value < convertedB.Value;
    }

    // Greater than or equal to operator
    public static bool operator >=(Money a, Money b)
    {
        return (a > b) || (a == b);
    }

    // Less than or equal to operator
    public static bool operator <=(Money a, Money b)
    {
        return (a < b) || (a == b);
    }

    // Override Equals() and GetHashCode()
    public override bool Equals(object? obj) // Note the nullable object? type
{
    if (ReferenceEquals(obj, null))
    {
        return false;
    }

    if (ReferenceEquals(this, obj))
    {
        return true;
    }

    if (obj.GetType() != this.GetType())
    {
        return false;
    }

    return this == (Money)obj;
}


    public override int GetHashCode()
    {
        return ConvertTo("USD").Value.GetHashCode();
    }
}