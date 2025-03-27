
namespace task_1
{
    class Enterprise
    {
		public string Name { get; set; }
		public int EmployeeCount { get; set; }
		public double PaymentPerHour { get; set; }
		public double IncomeTax { get; set; }

		public Enterprise(string name, int employeeCount, double paymentPerHour, double incomeTax)
		{
			Name = name;
			EmployeeCount = employeeCount;
			PaymentPerHour = paymentPerHour;
			IncomeTax = incomeTax;
		}


		private ProductionNorm norm;

		public double CalculateTotalIncomeTax()
		{
			norm = ProductionNorm.GetInstance();
			double result = norm.MonthlyNorm * PaymentPerHour * EmployeeCount * IncomeTax;
			return result;
		}

		public double InfoMonthlyHoursNorm()
		{
			return ProductionNorm.GetInstance().MonthlyNorm;
		}

		public void GetInfo()
		{
			Console.WriteLine($"Предприятие: {Name}");
			Console.WriteLine($"Количество работников: {EmployeeCount}");
			Console.WriteLine($"Оплата за час: {PaymentPerHour}");
			Console.WriteLine($"Подоходный налог: {IncomeTax}");
			Console.WriteLine($"Норму выработки часов в месяц: {ProductionNorm.GetInstance().MonthlyNorm}");
			Console.WriteLine($"Общая выплата по подоходному налогу: {CalculateTotalIncomeTax()}");
		}
	}
}
