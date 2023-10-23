using System.Data.SqlClient;


namespace ConsoleAppCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConnection;
            String connectionString = @"Data Source=DESKTOP-FG8G567\SQLEXPRESS01;
                                        Initial Catalog=AssignmentFive;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            try
            {

                Console.WriteLine("Database connected successfully");
                string answer;
                do
                {
                    Console.WriteLine("Select from the options\n1.Create Employee\n2.Retrieve Employee\n3.Update Employee\n4.Delete Employee\n5.Search By Id");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            //Create
                            Console.WriteLine("Enter your first name: ");
                            String FirstName = Console.ReadLine();

                            Console.WriteLine("Enter your last name: ");
                            String LastName = Console.ReadLine();

                            Console.WriteLine("Enter your email: ");
                            String Email = Console.ReadLine();

                            Console.WriteLine("Enter your primary phone number: ");
                            String PrimaryPhoneNumber = Console.ReadLine();

                            Console.WriteLine("Enter your secondary phone number: ");
                            String SecondaryPhoneNumber = Console.ReadLine();

                            Console.WriteLine("Created By: ");
                            String CreatedBy = Console.ReadLine();

                            DateTime CreatedOn = DateTime.Now;

                            String insertQuery = "INSERT INTO Employees (FirstName, LastName, Email, PrimaryPhoneNumber," +
                                "SecondaryPhoneNumber,CreatedBy,CreatedOn,ModifiedBy,ModifiedOn) VALUES('" + FirstName + "','" + LastName + "', '" + Email + "','" + PrimaryPhoneNumber + "','" +
                                SecondaryPhoneNumber + "','" + CreatedBy + "','" + CreatedOn + "','" + CreatedBy + "','" + CreatedOn + "')";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("Data stored successfully");
                            break;
                        case 2:
                            //Retrieve
                            String displayQuery = "SELECT * FROM Employees";
                            SqlCommand viewCommand = new SqlCommand(displayQuery, sqlConnection);
                            SqlDataReader dataReader = viewCommand.ExecuteReader();
                            while (dataReader.Read())
                            {
                                Console.WriteLine("First Name " + dataReader.GetValue(1).ToString());
                                Console.WriteLine("Last Name: " + dataReader.GetValue(2).ToString());
                                Console.WriteLine("Email: " + dataReader.GetValue(3).ToString());
                                Console.WriteLine("Primary Contact No. : " + dataReader.GetValue(4).ToString());
                                Console.WriteLine("Secondary Contact No. : " + dataReader.GetValue(5).ToString());
                                Console.WriteLine("Created by: " + dataReader.GetValue(6).ToString());
                                Console.WriteLine("Created on: " + dataReader.GetValue(7).ToString());
                                Console.WriteLine("Modified by: " + dataReader.GetValue(8).ToString());
                                Console.WriteLine("Modified on: " + dataReader.GetValue(9).ToString());
                                Console.WriteLine("----------------------------------------------------");
                            }
                            dataReader.Close();
                            break;
                        case 3:
                            //update
                            int id;
                            String ModifiedFirstName;
                            String ModifiedLastName;
                            String ModifiedEmail;
                            String ModifiedPrimaryPhoneNumber;
                            String ModifiedSecondaryPhoneNumber;
                            String ModifiedBy;
                            DateTime ModifiedOn = DateTime.Now;

                            Console.WriteLine("Enter the ID of the entry to be updated:");
                            id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the new first name (or press Enter to keep it unchanged):");
                            ModifiedFirstName = Console.ReadLine();

                            Console.WriteLine("Enter the new last name (or press Enter to keep it unchanged):");
                            ModifiedLastName = Console.ReadLine();

                            Console.WriteLine("Enter the new email (or press Enter to keep it unchanged):");
                            ModifiedEmail = Console.ReadLine();

                            Console.WriteLine("Enter the new primary contact number (or press Enter to keep it unchanged):");
                            ModifiedPrimaryPhoneNumber = Console.ReadLine();

                            Console.WriteLine("Enter the new secondary contact number (or press Enter to keep it unchanged):");
                            ModifiedSecondaryPhoneNumber = Console.ReadLine();

                            Console.WriteLine("Modified by: ");
                            ModifiedBy = Console.ReadLine();

                            string updateQuery = "UPDATE Employees SET ";

                            if (!string.IsNullOrEmpty(ModifiedFirstName))
                            {
                                updateQuery += $"FirstName = '{ModifiedFirstName}', ";
                            }

                            if (!string.IsNullOrEmpty(ModifiedLastName))
                            {
                                updateQuery += $"LastName = '{ModifiedLastName}', ";
                            }

                            if (!string.IsNullOrEmpty(ModifiedEmail))
                            {
                                updateQuery += $"Email = '{ModifiedEmail}', ";
                            }

                            if (!string.IsNullOrEmpty(ModifiedPrimaryPhoneNumber))
                            {
                                updateQuery += $"PrimaryPhoneNumber = '{ModifiedPrimaryPhoneNumber}', ";
                            }

                            if (!string.IsNullOrEmpty(ModifiedSecondaryPhoneNumber))
                            {
                                updateQuery += $"SecondaryPhoneNumber = '{ModifiedSecondaryPhoneNumber}', ";
                            }

                            if (!string.IsNullOrEmpty(ModifiedBy))
                            {
                                updateQuery += $"ModifiedBy = '{ModifiedBy}', ";
                            }

                            // Remove the trailing ", " from the updateQuery if any columns were updated
                            if (updateQuery.EndsWith(", "))
                            {
                                updateQuery = updateQuery.Substring(0, updateQuery.Length - 2);
                            }

                            updateQuery += $" WHERE ID = {id}";

                            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                            updateCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully updated");
                            break;
                        case 4:
                            //delete
                            int emp_id;
                            Console.WriteLine("Enter the id of the employee to be removed");
                            emp_id = int.Parse(Console.ReadLine());
                            String deleteQuery = "DELETE FROM Employees WHERE ID = " + emp_id + "";
                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                            deleteCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully deleted");
                            break;
                        case 5:
                            //delete
                            int search_id;
                            Console.WriteLine("Enter the id of the employee");
                            search_id = int.Parse(Console.ReadLine());
                            String searchQuery = "SELECT * FROM Employees WHERE ID = " + search_id + "";
                            SqlCommand searchCommand = new SqlCommand(searchQuery, sqlConnection);
                            searchCommand.ExecuteNonQuery();
                            Console.WriteLine("Successfully deleted");
                            break;
                        default:
                            Console.WriteLine("Please enter the valid choice");
                            break;
                    }
                    Console.WriteLine("Do you want to continue? (y/n)");
                    answer = Console.ReadLine();
                } while (answer != "N" || answer != "n");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }


        }
    }
}


//using System;
//using System.Data;
//using System.Data.SqlClient;

//namespace ConsoleAppCrud
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            SqlConnection sqlConnection;
//            String connectionString = @"Data Source=DESKTOP-FG8G567\SQLEXPRESS01;
//                                        Initial Catalog=AssignmentFive;
//                                        Integrated Security=True;
//                                        Connect Timeout=30;
//                                        Encrypt=False;";
//            sqlConnection = new SqlConnection(connectionString);
//            sqlConnection.Open();

//            try
//            {
//                Console.WriteLine("Database connected successfully");
//                string answer;

//                do
//                {
//                    Console.WriteLine("Select from the options\n1.Create Employee\n2.Retrieve Employee\n3.Update Employee\n4.Delete Employee\n5.Search By Id");
//                    int choice = int.Parse(Console.ReadLine());
//                    DataTable dataTable = new DataTable();
//                    string displayQuery = "SELECT * FROM Employees";
//                    SqlDataAdapter dataAdapter = new SqlDataAdapter(displayQuery, sqlConnection);
//                    dataAdapter.Fill(dataTable);

//                    switch (choice)
//                    {
//                        case 1:

//                            Console.WriteLine("Enter your first name: ");
//                            String FirstName = Console.ReadLine();

//                            Console.WriteLine("Enter your last name: ");
//                            String LastName = Console.ReadLine();

//                            Console.WriteLine("Enter your email: ");
//                            String Email = Console.ReadLine();

//                            Console.WriteLine("Enter your primary phone number: ");
//                            String PrimaryPhoneNumber = Console.ReadLine();

//                            Console.WriteLine("Enter your secondary phone number: ");
//                            String SecondaryPhoneNumber = Console.ReadLine();

//                            Console.WriteLine("Created By: ");
//                            String CreatedBy = Console.ReadLine();

//                            DateTime CreatedOn = DateTime.Now;



//                            SqlCommandBuilder addBuilder = new SqlCommandBuilder(dataAdapter);

//                            addBuilder.GetInsertCommand();


//                            // Create a new row for the DataTable
//                            DataRow newRow = dataTable.NewRow();
//                            newRow["FirstName"] = FirstName;
//                            newRow["LastName"] = LastName;
//                            newRow["Email"] = Email;
//                            newRow["PrimaryPhoneNumber"] = PrimaryPhoneNumber;
//                            newRow["SecondaryPhoneNumber"] = SecondaryPhoneNumber;
//                            newRow["CreatedBy"] = CreatedBy;
//                            newRow["CreatedOn"] = CreatedOn;

//                            // Add the new row to the DataTable
//                            dataTable.Rows.Add(newRow);

//                            // Update the database using the data adapter
//                            dataAdapter.Update(dataTable);

//                            Console.WriteLine("Data stored successfully");
//                            break;
//                        case 2:
//                            // Retrieve

//                            Console.WriteLine("---------------------------------------------------------------------------------------------");
//                            Console.WriteLine("| First Name   | Last Name    | Email                      | Primary Contact | Secondary Contact |");
//                            Console.WriteLine("---------------------------------------------------------------------------------------------");

//                            foreach (DataRow row in dataTable.Rows)
//                            {
//                                Console.WriteLine($"| {row["FirstName"],-14} | {row["LastName"],-14} | {row["Email"],-28} | {row["PrimaryPhoneNumber"],-16} | {row["SecondaryPhoneNumber"],-19} |");
//                            }

//                            Console.WriteLine("---------------------------------------------------------------------------------------------");
//                            break;

//                        case 3:
//                            // Update
//                            int id;
//                            Console.WriteLine("Enter the ID of the entry to be updated:");
//                            id = int.Parse(Console.ReadLine());

//                            Console.WriteLine("Enter the new first name (or press Enter to keep it unchanged):");
//                            string ModifiedFirstName = Console.ReadLine();

//                            Console.WriteLine("Enter the new last name (or press Enter to keep it unchanged):");
//                            string ModifiedLastName = Console.ReadLine();

//                            Console.WriteLine("Enter the new email (or press Enter to keep it unchanged):");
//                            string ModifiedEmail = Console.ReadLine();

//                            Console.WriteLine("Enter the new primary contact number (or press Enter to keep it unchanged):");
//                            string ModifiedPrimaryPhoneNumber = Console.ReadLine();

//                            Console.WriteLine("Enter the new secondary contact number (or press Enter to keep it unchanged):");
//                            string ModifiedSecondaryPhoneNumber = Console.ReadLine();

//                            Console.WriteLine("Modified by: ");
//                            string ModifiedBy = Console.ReadLine();

//                            DataRow[] rows = dataTable.Select("ID = " + id);

//                            if (rows.Length == 1)
//                            {
//                                DataRow row = rows[0];

//                                // Update the row with new values
//                                if (!string.IsNullOrEmpty(ModifiedFirstName))
//                                {
//                                    row["FirstName"] = ModifiedFirstName;
//                                }

//                                if (!string.IsNullOrEmpty(ModifiedLastName))
//                                {
//                                    row["LastName"] = ModifiedLastName;
//                                }

//                                if (!string.IsNullOrEmpty(ModifiedEmail))
//                                {
//                                    row["Email"] = ModifiedEmail;
//                                }

//                                if (!string.IsNullOrEmpty(ModifiedPrimaryPhoneNumber))
//                                {
//                                    row["PrimaryPhoneNumber"] = ModifiedPrimaryPhoneNumber;
//                                }

//                                if (!string.IsNullOrEmpty(ModifiedSecondaryPhoneNumber))
//                                {
//                                    row["SecondaryPhoneNumber"] = ModifiedSecondaryPhoneNumber;
//                                }

//                                SqlCommandBuilder updateBuilder = new SqlCommandBuilder(dataAdapter);

//                                updateBuilder.GetUpdateCommand();

//                                dataAdapter.Update(dataTable);

//                                Console.WriteLine("Successfully updated");
//                            }
//                            else
//                            {
//                                Console.WriteLine("No employee found with the specified ID.");
//                            }

//                            break;


//                        case 4:
//                            // Delete
//                            int emp_id;
//                            Console.WriteLine("Enter the id of the employee to be removed");
//                            emp_id = int.Parse(Console.ReadLine());

//                            DataRow[] empRows = dataTable.Select("ID = " + emp_id);

//                            if (empRows.Length == 1)
//                            {
//                                DataRow row = empRows[0];
//                                row.Delete();
//                                SqlCommandBuilder deleteBuilder = new SqlCommandBuilder(dataAdapter);
//                                deleteBuilder.GetDeleteCommand();
//                                dataAdapter.Update(dataTable);
//                                Console.WriteLine("Successfully deleted");
//                            }
//                            else
//                            {
//                                Console.WriteLine("No employee found with the specified ID.");
//                            }


//                            break;

//                        case 5:
//                            // Delete
//                            int search_id;
//                            Console.WriteLine("Enter the id of the employee: ");
//                            search_id = int.Parse(Console.ReadLine());

//                            DataRow[] searchRows = dataTable.Select("ID = " + search_id);

//                            if (searchRows.Length == 1)
//                            {
//                                DataRow row = searchRows[0];
//                                Console.WriteLine("---------------------------------------------------------------------------------------------");
//                                Console.WriteLine("| First Name   | Last Name    | Email                      | Primary Contact | Secondary Contact |");
//                                Console.WriteLine("---------------------------------------------------------------------------------------------");
//                                   Console.WriteLine($"| {row["FirstName"],-14} | {row["LastName"],-14} | {row["Email"],-28} | {row["PrimaryPhoneNumber"],-16} | {row["SecondaryPhoneNumber"],-19} |");
//                            }
//                            else
//                            {
//                                Console.WriteLine("No employee found with the specified ID.");
//                            }

//                            break;

//                        default:
//                            Console.WriteLine("Please enter a valid choice");
//                            break;
//                    }

//                    Console.WriteLine("Do you want to continue? (y/n)");
//                    answer = Console.ReadLine();
//                } while (answer != "N" && answer != "n");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//            finally
//            {
//                sqlConnection.Close();
//            }
//        }
//    }
//}
