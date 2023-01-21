using System;
using System.Collections.Generic;

namespace ConsoleNotebook
{
    // Класс, хранящий информацию о заметке
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Note(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }

    // Класс, хранящий коллекцию заметок и предоставляющий функции управления ими
    public class NotesCollection
    {
        private List<Note> notes;

        public NotesCollection()
        {
            notes = new List<Note>();
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        public void RemoveNote(Note note)
        {
            notes.Remove(note);
        }

        public Note GetNote(int index)
        {
            return notes[index];
        }

        public int Count
        {
            get { return notes.Count; }
        }
    }
    // Класс, реализующий функции управления и отображения заметок с помощью консоли
    public class Notebook
    {
        private NotesCollection notes;
        private int selectedIndex;

        public Notebook()
        {
            // Создаем экземпляр коллекции заметок
            notes = new NotesCollection();

            // Добавляем тестовые заметки
            notes.AddNote(new Note("1.12.2022", "Отжимания"));
            notes.AddNote(new Note("2.12.2022", "Прес качат"));
            notes.AddNote(new Note("3.12.2022", "Отдыхать"));
            notes.AddNote(new Note("4.12.2022", "Кайфовать"));
            notes.AddNote(new Note("5.12.2022", "Сделать практическую"));

            // Выбираем первую заметку
            selectedIndex = 0;
        }

        // Метод для отображения стрелочного меню со списком заметок
        public void ShowMenu()
        {
            Console.Clear();

            // Отображаем список заметок
            for (int i = 0; i < notes.Count; i++)
            {
                if (i == selectedIndex)
                {
                    // Если заметка выбрана, отображаем ее с указанием номера и названия
                    Console.WriteLine($"-> {notes.GetNote(i).Title}");
                }
                else
                {
                    // Иначе отображаем только название
                    Console.WriteLine($"  {notes.GetNote(i).Title}");
                }
            }
        }

        // Метод для обработки нажатия клавиш управления
        public void ProcessInput()
        {
            // Читаем нажатую клавишу
            ConsoleKeyInfo key = Console.ReadKey();

            // Обрабатываем нажатие клавиш управления
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    // Переключаемся на предыдущую заметку
                    if (selectedIndex > 0)
                    {
                        selectedIndex--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    // Переключаемся на следующую заметку
                    if (selectedIndex < notes.Count - 1)
                    {
                        selectedIndex++;
                    }
                    break;
                case ConsoleKey.Enter:
                    // Отображаем подробную информацию о выбранной заметке
                    ShowNoteDetails();
                    break;
            }
        }

        // Метод для отображения подробной информации о выбранной заметке
        private void ShowNoteDetails()
        {
            // Получаем выбранную заметку
            Note selectedNote = notes.GetNote(selectedIndex);

            // Отображаем информацию о заметке
            Console.Clear();
            Console.WriteLine("Название: " + selectedNote.Title);
            Console.WriteLine("Описание: " + selectedNote.Description);

            // Ждем нажатия любой клавиши для возврата в меню
            Console.ReadKey();

        }
        static void Main(string[] args)
        {
            // Создаем экземпляр класса Notebook
            Notebook notebook = new Notebook();

            // Вызываем метод ShowMenu() в цикле, чтобы отображать меню и обрабатывать нажатия клавиш
            while (true)
            {
                notebook.ShowMenu();
                notebook.ProcessInput();
            }
        }

    }
}
