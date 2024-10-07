class DateTimeManager
{
    private int _day;
    private int _month;
    private int _year;

    public int Day
    {
        get => _day;
        set => _day = ValidateDay(value, _month, _year) ? value : 1;
    }

    public int Month
    {
        get => _month;
        set
        {
            _month = (value >= 1 && value <= 12) ? value : 1;
            _day = (_day > DaysInMonth(_month, _year)) ? DaysInMonth(_month, _year) : _day;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            _year = (value > 0) ? value : 2023;
            _day = (_day > DaysInMonth(_month, _year)) ? DaysInMonth(_month, _year) : _day;
        }
    }

    public string WeekdayName => GetDayOfWeekName();

    public DateTimeManager() : this(1, 1, 1900) { }

    public DateTimeManager(int day, int month, int year)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    private bool ValidateDay(int day, int month, int year)
    {
        return day >= 1 && day <= DaysInMonth(month, year);
    }

    public int CalculateDayDifference(DateTimeManager otherDate)
    {
        int currentDays = ConvertToTotalDays(_year, _month, _day);
        int otherDays = ConvertToTotalDays(otherDate._year, otherDate._month, otherDate._day);
        return Math.Abs(currentDays - otherDays);
    }

    private int ConvertToTotalDays(int year, int month, int day)
    {
        int daysCount = day;

        for (int y = 1; y < year; y++)
            daysCount += IsLeapYear(y) ? 366 : 365;

        for (int m = 1; m < month; m++)
            daysCount += DaysInMonth(m, year);

        return daysCount;
    }

    public void ShiftDateByDays(int days)
    {
        int totalDays = ConvertToTotalDays(_year, _month, _day) + days;

        _year = 1;
        while (totalDays >= (IsLeapYear(_year) ? 366 : 365))
        {
            totalDays -= IsLeapYear(_year) ? 366 : 365;
            _year++;
        }

        _month = 1;
        while (totalDays > DaysInMonth(_month, _year))
        {
            totalDays -= DaysInMonth(_month, _year);
            _month++;
        }

        _day = totalDays;
    }

    public override string ToString() => $"{_day:D2}/{_month:D2}/{_year}";

    private int DaysInMonth(int month, int year)
    {
        return month switch
        {
            1 => 31,
            2 => IsLeapYear(year) ? 29 : 28,
            3 => 31,
            4 => 30,
            5 => 31,
            6 => 30,
            7 => 31,
            8 => 31,
            9 => 30,
            10 => 31,
            11 => 30,
            12 => 31,
            _ => 1,
        };
    }

    private bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    private string GetDayOfWeekName()
    {
        int adjustedMonth = (_month < 3) ? _month + 12 : _month;
        int century = _year / 100;
        int yearOfCentury = _year % 100;

        int dayOfWeek = (_day + (13 * (adjustedMonth + 1)) / 5 + yearOfCentury + (yearOfCentury / 4) +
                        (century / 4) - 2 * century) % 7;
        dayOfWeek = (dayOfWeek + 7) % 7;

        return dayOfWeek switch
        {
            0 => "Sunday",
            1 => "Monday",
            2 => "Tuesday",
            3 => "Wednesday",
            4 => "Thursday",
            5 => "Friday",
            6 => "Saturday",
            _ => "Unidentified"
        };
    }

    public static int operator -(DateTimeManager d1, DateTimeManager d2)
    {
        return d1.CalculateDayDifference(d2);
    }

    public static DateTimeManager operator +(DateTimeManager date, int days)
    {
        DateTimeManager result = new DateTimeManager(date._day, date._month, date._year);
        result.ShiftDateByDays(days);
        return result;
    }

    public static bool operator >(DateTimeManager d1, DateTimeManager d2)
    {
        return d1.CalculateDayDifference(d2) < 0;
    }

    public static bool operator <(DateTimeManager d1, DateTimeManager d2)
    {
        return d1.CalculateDayDifference(d2) > 0;
    }

    public static bool operator ==(DateTimeManager d1, DateTimeManager d2)
    {
        return d1.CalculateDayDifference(d2) == 0;
    }

    public static bool operator !=(DateTimeManager d1, DateTimeManager d2)
    {
        return d1.CalculateDayDifference(d2) != 0;
    }

    public static DateTimeManager operator ++(DateTimeManager d)
    {
        DateTimeManager newDate = new DateTimeManager(d._day, d._month, d._year);
        newDate.ShiftDateByDays(1);
        return newDate;
    }

    public static DateTimeManager operator --(DateTimeManager d)
    {
        DateTimeManager newDate = new DateTimeManager(d._day, d._month, d._year);
        newDate.ShiftDateByDays(-1);
        return newDate;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            DateTimeManager defaultDate = new DateTimeManager();
            Console.WriteLine($"Default date: {defaultDate}");

            DateTimeManager customDate = new DateTimeManager(7, 10, 2024);
            Console.WriteLine($"Custom date: {customDate}");

            Console.WriteLine($"Day of the week: {customDate.WeekdayName}");

            int difference = customDate - defaultDate;
            Console.WriteLine($"Difference in days: {difference}");

            customDate += 29;
            Console.WriteLine($"Date after change by 29 days: {customDate}");

            DateTimeManager date1 = new DateTimeManager(10, 10, 2024);
            DateTimeManager date2 = new DateTimeManager(20, 10, 2024);

            Console.WriteLine($"Difference between date1 and date2: {date2 - date1} days");

            date1++;
            Console.WriteLine($"date1 after the operator ++: {date1}");

            date2--;
            Console.WriteLine($"date2 after the operator --: {date2}");

            Console.WriteLine($"Is date1 greater than date2? {date1 > date2}");
            Console.WriteLine($"Is date1 less than date2? {date1 < date2}");
            Console.WriteLine($"Is date1 equal to date2? {date1 == date2}");
            Console.WriteLine($"Is date1 not equal to date2? {date1 != date2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
