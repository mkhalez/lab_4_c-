
namespace task_1_
{
	class Enterprise
	{

		private static Enterprise instance;

		private ProductionNorm norm;
		public string Name { get; set; }
		public int EmployeeCount { get; set; }
		public double PaymentPerHour { get; set; }
		public double IncomeTaxRate { get; set; }

		public Enterprise(string name, int employeeCount, double paymentPerHour, double incomeTaxRate)
		{
			Name = name;
			EmployeeCount = employeeCount;
			PaymentPerHour = paymentPerHour;
			IncomeTaxRate = incomeTaxRate;
			norm = new ProductionNorm();
		}

		public static Enterprise GetInstance(string name, int employeeCount, double paymentPerHour, double incomeTaxRate)
		{
			if (instance == null)
			{
				instance = new Enterprise(name, employeeCount, paymentPerHour, incomeTaxRate);
			}
			return instance;
		}


		public double CalculateTotalIncomeTax()
		{
			return norm.MonthlyHoursNorm * PaymentPerHour * EmployeeCount * IncomeTaxRate;
		}

		public double InfoMonthlyHoursNorm()
		{
			return norm.MonthlyHoursNorm;
		}

		public void ChangeNorm(int hours)
		{
			norm.IncreaseNorm(hours);
		}

		public void GetInfo()
		{
			Console.WriteLine($"Предприятие: {Name}");
			Console.WriteLine($"Количество работников: {EmployeeCount}");
			Console.WriteLine($"Оплата за час: {PaymentPerHour}");
			Console.WriteLine($"Подоходный налог: {IncomeTaxRate}");
			Console.WriteLine($"Норму выработки часов в месяц: {norm.MonthlyHoursNorm}");
			Console.WriteLine($"Общая выплата по подоходному налогу: {CalculateTotalIncomeTax()}");
		}
	}
}
