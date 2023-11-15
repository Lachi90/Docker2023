import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Book } from 'src/model/book';

@Injectable({
    providedIn: 'root'
})
export class BookService {
    private backendUrl: string = environment.backendUrl;
    
    constructor(private httpClient: HttpClient) { }
    
    getBooks(): Observable<Book[]> {
        return this.httpClient.get<Book[]>(`${this.backendUrl}/books`);
    }

    getBook(id: number): Observable<Book> {
        return this.httpClient.get<Book>(`${this.backendUrl}/${id}`);
    }

    createBook(book: Book): Observable<Book> {
        return this.httpClient.post<Book>(`${this.backendUrl}/create`, book);
    }

    updateBook(book: Book): Observable<Book> {
        return this.httpClient.put<Book>(`${this.backendUrl}/update`, book);
    }

    deleteBook(id: number) {
        return this.httpClient.delete(`${this.backendUrl}/${id}`);
    }
}