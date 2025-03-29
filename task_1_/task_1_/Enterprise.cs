
namespace task_1_
{
	class Enterprise
	{

		private static Enterprise instance;

		private ProductionNorm norm;

		private string Name;
		private int EmployeeCount;
		private double PaymentPerHour, IncomeTaxRate;
		public string NameCheck
		{
			get => Name;
			set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException();
				}

				Name = value;
			}
		}
		public int EmployeeCountCheck
		{
			get => EmployeeCount;
			set
			{
				if(value <= 0)
				{
					throw new ArgumentException();
				}

				EmployeeCount = value;
			}
		}
		public double PaymentPerHourCheck
		{
			get => PaymentPerHour;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException();
				}

				PaymentPerHour = value;
			}
		}
		public double IncomeTaxRateCheck
		{
			get => IncomeTaxRate;
			set
			{
				if(value < 0 || value > 100)
				{
					throw new ArgumentException();
				}

				IncomeTaxRate = value / 100;
			}
		}

		public Enterprise()
		{
			norm = new ProductionNorm();
		}

		public static Enterprise GetInstance()
		{
			if (instance == null)
			{
				instance = new Enterprise();
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
			if (norm.MonthlyHoursNorm + hours < 0)
			{
				throw new ArgumentException();
			}
			norm.IncreaseNorm(hours);
		}

		public string GetInfo()
		{
			return $"Предприятие: {Name}\n" + $"Количество работников: {EmployeeCount}\n" + $"Оплата за час: {PaymentPerHour}\n" + $"Подоходный налог: {IncomeTaxRate}\n" + $"Норма выработки часов в месяц: {norm.MonthlyHoursNorm}\n" + $"Общая выплата по подоходному налогу: {CalculateTotalIncomeTax()}";
		}
	}
}
