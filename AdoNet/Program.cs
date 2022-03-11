using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CustomerObjects;
using DataAccessLayer;

namespace AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int choice;
			do
			{
				Console.WriteLine("Customer Management System");
				Console.WriteLine("1.Create Record"); ; //C-reate
				Console.WriteLine("2.Display Record");  //R-ead
				Console.WriteLine("3.Update Record");   //U-pdate
				Console.WriteLine("4.Delete Record");   //D-elete
				Console.WriteLine("5.Exit");
				Console.WriteLine("6.Update New");
				Console.WriteLine("Enter your choice(1 / 2 / 3 / 4 /5)");
				choice = int.Parse(Console.ReadLine());
				int RowsAffected =0;
				
				switch (choice)
				{
					case 1:
						Console.WriteLine("Creating Customer Record");

						Customer customer = new Customer();

						Console.WriteLine("Enter Customer Name");
						customer.Name = Console.ReadLine();

						Console.WriteLine("Enter City Name");
						customer.City = Console.ReadLine();

						Console.WriteLine("Enter Phone Number");
						customer.PhoneNumber = Console.ReadLine();
						 RowsAffected = CrudOperations.SaveEmployee(customer);

						if (RowsAffected > 0)
							Console.WriteLine("Record Inserted Successfully....");
						else
							Console.WriteLine("Record insertion not successfull");


						break;
					case 2:
						Console.WriteLine("Displaying Customer Record");
						List<Customer> customers = CrudOperations.GetAllCustomers();

						foreach (Customer Cust in customers)
						{
							Console.WriteLine(Cust.ID.ToString() + "-" + Cust.Name + Cust.City + Cust.PhoneNumber);
						}

						break;
					case 3:
						Console.WriteLine("Updating customer Record");

						Customer customerNeededToUpdate = new Customer();
						Console.WriteLine("Enter Customer Name");
						customerNeededToUpdate.ID = int.Parse(Console.ReadLine());

						Console.WriteLine("Enter Customer Name");
						customerNeededToUpdate.Name = Console.ReadLine();

						Console.WriteLine("Enter City Name");
						customerNeededToUpdate.City = Console.ReadLine();

						Console.WriteLine("Enter Phone Number");
						customerNeededToUpdate.PhoneNumber = Console.ReadLine();
						RowsAffected = CrudOperations.UpdateCustomer(customerNeededToUpdate);

						if (RowsAffected > 0)
							Console.WriteLine("Record Updated Successfully....");
						else
							Console.WriteLine("Record updation not successfull");
						break;
					case 4:
						Console.WriteLine("Deleting customer Record");
						int ID = int.Parse(Console.ReadLine());
						RowsAffected = CrudOperations.DeleteCustomer(ID);
						if (RowsAffected > 0)
							Console.WriteLine("Record Deleted Successfully....");
						else
							Console.WriteLine("Record Deletion not successfull");

						break;
					case 5:
						Console.WriteLine("Thank you. Come Again");
						break;
					case 6:
						Console.WriteLine("Updation for all fields !!");
						Console.Write("\nEnter your ID : ");
						int Idd = int.Parse(Console.ReadLine());
						Console.WriteLine("1.Name\n2.City\n3.PhoneNumber");
						string colname = Console.ReadLine();
						string colvalue = Console.ReadLine();
						RowsAffected = CrudOperations.UpdateByAttrCustomer(colname,colvalue,Idd);
						if (RowsAffected > 0)
							Console.WriteLine("Record Updated Successfully....");
						else
							Console.WriteLine("Record Updation not successfull");



						break;
					default:
						Console.WriteLine("Please give valid choice 1 to 5 only");
						break;
				}

				Console.ReadKey();  //Pause the execution upto keypress event..

			} while (choice >= 1 && choice < 7);
		}
    }
}
