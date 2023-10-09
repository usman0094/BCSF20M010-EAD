using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmnet_03
{
	public  class StudentDatabase
	{

		private Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

		// Function to add student records to the dictionary
		public void AddStudent(int studentID, string name)
		{
			studentDictionary[studentID] = name;
		}

		// Function to retrieve the student's name by student ID
		public string GetStudentName(int studentID)
		{
			if (studentDictionary.ContainsKey(studentID))
			{
				return studentDictionary[studentID];
			}
			else
			{
				return "Student ID not found";
			}
		}

		// Function to display the entire student database
		public void DisplayStudentDatabase()
		{
			Console.WriteLine("Student Database:");
			foreach (var kvp in studentDictionary)
			{
				Console.WriteLine($"Student ID: {kvp.Key}, Name: {kvp.Value}");
			}
		}

		// Function to update a student's name by student ID
		public void UpdateStudentName(int studentID, string newName)
		{
			if (studentDictionary.ContainsKey(studentID))
			{
				studentDictionary[studentID] = newName;
				Console.WriteLine($"Updated student ID {studentID}'s name to {newName}");
			}
			else
			{
				Console.WriteLine("Student ID not found");
			}
		}
	}

}


