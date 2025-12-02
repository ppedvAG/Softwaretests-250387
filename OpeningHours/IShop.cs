namespace OpeningHours;

public interface IShop
{
	bool IsWeekend();

	bool IsOpen();

	bool IsOpen(DateTime dt);
}
