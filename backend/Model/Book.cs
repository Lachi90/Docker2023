﻿#nullable disable

namespace ExampleBackend.Model;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Isbn { get; set; }
}