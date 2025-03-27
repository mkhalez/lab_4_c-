
namespace task_1_
{
	public class ProductionNorm
	{
		public int MonthlyHoursNorm { get; private set; }

		public ProductionNorm()
		{
			MonthlyHoursNorm = 160;
		}

		public void IncreaseNorm(int hours)
		{
			MonthlyHoursNorm += hours;
		}
	}
}
