namespace OpeningHours;

public class Shop : IShop
{
	public DateTime ToCheck;

	public virtual bool IsWeekend()
	{
		return DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
	}

	public virtual bool IsOpen()
	{
		if (!IsWeekend())
		{
			if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 17)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsOpen(DateTime dt)
	{
		if (dt.DayOfWeek >= DayOfWeek.Monday && dt.DayOfWeek <= DayOfWeek.Friday)
		{
			if (dt.Hour >= 9 && dt.Hour <= 17)
			{
				return true;
			}
		}
		return false;
	}
}
