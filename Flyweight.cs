using System;
using System.Collections.Generic;

namespace Assignment_07
{

	// Example 1: Text Formatting

	// Flyweight
	public class TextFormat
	{
		private readonly ConsoleColor color;

		public TextFormat(ConsoleColor color)
		{
			this.color = color;
		}

		public void Apply()
		{
			Console.ForegroundColor = color;
		}
	}

	// Context
	public class TextCharacter
	{
		private readonly char character;
		private readonly TextFormat format;

		public TextCharacter(char character, ConsoleColor color)
		{
			this.character = character;
			this.format = new TextFormat(color);
		}

		public void Display()
		{
			format.Apply();
			Console.Write(character);
			Console.ResetColor();
		}
	}

	// Example 2: Musical Notes

	// Flyweight
	public class Note
	{
		private readonly string symbol;

		public Note(string symbol)
		{
			this.symbol = symbol;
		}

		public void Play(string key)
		{
			Console.WriteLine($"Note {symbol} played on {key}");
		}
	}

	// Context
	public class MusicalComposition
	{
		private readonly List<Note> notes = new List<Note>();

		public void AddNote(string symbol)
		{
			notes.Add(new Note(symbol));
		}

		public void PlayNotes(string key)
		{
			foreach (var note in notes)
			{
				note.Play(key);
			}
		}
	}

}