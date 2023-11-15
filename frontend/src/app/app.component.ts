import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/service/book.service';
import { Book } from 'src/model/book';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  books: Observable<Book[]> = new Observable();

  newBook: Book = {
    title: '',
    author: '',
    year: undefined,
    isbn: '',
    id: 0
  }

  constructor(private bookService: BookService) { }

  ngOnInit() {
    this.getBooks();
  }

  addBook() {
    this.bookService.createBook(this.newBook).subscribe(() => {
      this.getBooks();
    })
    this.newBook = { id: 0, title: '', author: '', year: undefined, isbn: '' };
  }

  getBooks() {
    this.books = this.bookService.getBooks();
  }

  deleteBook(book: Book) {
    this.bookService.deleteBook(book.id).subscribe(() => {
      this.getBooks();
    });
  }
}
