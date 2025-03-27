namespace task_1_
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Run();
		}

		static void Run()
		{
			Console.WriteLine("6 Вариант");
			Console.WriteLine();

			Enterprise enterprise;

			while (true)
			{
				Console.WriteLine("Введите название предприятия: ");
				string name = InputString();

				Console.WriteLine("Введите количество работников: ");
				int employeeCount = InputInt();

				Console.WriteLine("Введите оплату за час работника: ");
				double paymentPerHour = InputDoublePaymen();

				Console.WriteLine("Введите подоходный налог с каждого работника в %: ");
				double incomeTax = InputDoubleTax() / 100;

				enterprise = new Enterprise(name, employeeCount, paymentPerHour, incomeTax);

				Console.WriteLine($"Сейчас норма выработки часов в месяц: {enterprise.InfoMonthlyHoursNorm()}");
				Console.WriteLine("Изменить норму? (введиет число: 1 - да, 0 - нет): ");

				bool decision = InputDecisionYesNo();
				if (decision)
				{
					Console.WriteLine("Введите на сколько вы хотите изменить норму: ");
					int changes = InputDecisionChanges();
					enterprise.ChangeNorm(changes);
				}

				Console.WriteLine("--------------------------------------");
				enterprise.GetInfo();
				Console.WriteLine();

				Console.WriteLine("Do you want to continue or stop[Y/n]");
				string decicion = Console.ReadLine() ?? string.Empty;
				bool result = CorrectFinishAnswer(decicion);
				if (!result) break;
			}

		}

		static string InputString()
		{
			while (true)
			{
				string value = Console.ReadLine() ?? string.Empty;

				value = value.Trim();

				if (string.IsNullOrEmpty(value))
				{
					Console.WriteLine("Пустая строка без символов, введите значение");
				}
				else
				{
					return value;
				}
			}
		}

		static int InputInt()
		{
			string value;
			int getValueInInt;
			bool valid = false;

			while (!valid)
			{
				value = Console.ReadLine() ?? string.Empty;
				valid = int.TryParse(value, out getValueInInt);
				if (valid == false || getValueInInt <= 0)
				{
					Console.WriteLine("число работников это натуральное число");
					valid = false;
				}
				else
				{
					return getValueInInt;
				}
			}
			return 0;
		}

		static double InputDoublePaymen()
		{
			string value;
			double getValueInDouble;
			bool valid = false;

			while (!valid)
			{
				value = Console.ReadLine() ?? string.Empty;
				valid = double.TryParse(value, out getValueInDouble);
				if (valid == false || getValueInDouble < 0)
				{
					Console.WriteLine("оплата должна быть неотрицательным числом");
					valid = false;
				}
				else
				{
					return getValueInDouble;
				}
			}
			return 0.0;
		}

		static double InputDoubleTax()
		{
			string value;
			double getValueInDouble;
			bool valid = false;

			while (!valid)
			{
				value = Console.ReadLine() ?? string.Empty;
				valid = double.TryParse(value, out getValueInDouble);
				if (valid == false || getValueInDouble < 0 || getValueInDouble > 100)
				{
					Console.WriteLine("процент должен быть в пределах от 0 до 100");
					valid = false;
				}
				else
				{
					return getValueInDouble;
				}
			}
			return 0.0;
		}

		static bool InputDecisionYesNo()
		{
			string value;
			int getValueInInt;
			bool valid = false;

			while (!valid)
			{
				value = Console.ReadLine() ?? string.Empty;
				valid = int.TryParse(value, out getValueInInt);
				if (valid == false || (getValueInInt != 0 && getValueInInt != 1))
				{
					Console.WriteLine("вы должны ввести число 0 или 1");
					valid = false;
				}
				else
				{
					if (getValueInInt == 0) return false;
					else return true;
				}
			}
			return false;
		}

		static int InputDecisionChanges()
		{
			string value;
			int getValueInInt;
			bool valid = false;

			while (!valid)
			{
				value = Console.ReadLine() ?? string.Empty;
				valid = int.TryParse(value, out getValueInInt);
				if (valid == false)
				{
					Console.WriteLine("введите число");
					valid = false;
				}
				else
				{
					return getValueInInt;
				}
			}
			return 0;
		}

		static bool CorrectFinishAnswer(string answer)
		{
			while (true)
			{
				// Удаляем лишние пробелы в начале и конце строки
				answer = answer.Trim();

				if (string.IsNullOrEmpty(answer))
				{
					return true;
				}

				if (answer == "Y" || answer == "y") return true;
				else if (answer == "N" || answer == "n") return false;
				else
				{
					Console.WriteLine("It is not valid answer, try again:");
					answer = Console.ReadLine() ?? string.Empty;
				}
			}
		}
	}
}
