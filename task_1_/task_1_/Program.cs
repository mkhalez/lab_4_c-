using System.Threading.Channels;

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
				enterprise = new Enterprise();

				Console.WriteLine("Введите название предприятия: ");
				BestCheck(value => enterprise.NameCheck = (string)value, "пустая строка без символов, введите значение", -1);

				Console.WriteLine("Введите количество работников: ");
				BestCheck(value => enterprise.EmployeeCountCheck = (int)value, "число работников это натуральное число", 1);

				Console.WriteLine("Введите оплату за час работника: ");
				BestCheck(value => enterprise.PaymentPerHourCheck = (double)value, "оплата должна быть неотрицательным числом", 0);

				Console.WriteLine("Введите подоходный налог с каждого работника в %: ");
				BestCheck(value => enterprise.IncomeTaxRateCheck = (double)value, "процент должен быть в пределах от 0 до 100", 0);

				Console.WriteLine($"Сейчас норма выработки часов в месяц: {enterprise.InfoMonthlyHoursNorm()}");
				Console.WriteLine("Изменить норму? (введиет число: 1 - да, 0 - нет): ");

				bool decision = InputDecisionYesNo();
				if (decision)
				{
					Console.WriteLine("Введите на сколько вы хотите изменить норму: ");
					InputDecisionChanges(enterprise, "введеное значение должно быть целым, а результат не меньше 0");
				}

				Console.WriteLine("--------------------------------------");
				Console.WriteLine(enterprise.GetInfo());
				Console.WriteLine();

				Console.WriteLine("Do you want to continue or stop[Y/n]");
				string decicion = Console.ReadLine() ?? string.Empty;
				bool result = CorrectFinishAnswer(decicion);
				if (!result) break;
			}

		}

		static void BestCheck(Action<object> setter, string condition, int type)
		{
			while(true)
			{
				string input = Console.ReadLine() ?? string.Empty;
				try
				{
					object value;
					if(type == 1)
					{
						value = int.Parse(input);
					}
					else if(type == 0)
					{
						value = double.Parse(input);
					}
					else
					{
						value = input;
					}

					setter(value);
					return;
				}
				catch (Exception)
				{
					Console.WriteLine(condition);
				}
			}
		}

		static void InputDecisionChanges(Enterprise enterprise, string condition)
		{

			while(true)
			{
				string input = Console.ReadLine() ?? string.Empty;
				try
				{
					int value;
					value = int.Parse(input);
					enterprise.ChangeNorm(value);
					return;
				}
				catch (Exception)
				{
					Console.WriteLine(condition);
				}
			}
		}

		/*static string InputString()
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
		}*/

		/*static int InputInt()
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
		}*/

		/*static double InputDoublePaymen()
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
		}*/

		/*static double InputDoubleTax()
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
		*/
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
