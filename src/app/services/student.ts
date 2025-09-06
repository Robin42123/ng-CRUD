import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Student {
  id: number;
  name: string;
  class: string;
}

@Injectable({ providedIn: 'root' })
export class StudentService {
  private apiUrl = 'https://localhost:7115/api/angular'; // ✅ adjust port

  constructor(private http: HttpClient) { }

  // getEmployees(): Observable<Student[]> {
  //   return this.http.get<Student[]>(this.apiUrl);
  // }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.apiUrl}/getall`);
  }


  getStudentById(id: number): Observable<Student> {
    return this.http.get<Student>(`${this.apiUrl}/${id}`);
  }

  updateStudent(student: Student): Observable<Student> {
    return this.http.post<Student>(this.apiUrl, student);
    // ⚡ your API uses POST for Add/Edit together
  }

  addStudent(student: Student): Observable<Student> {
    return this.http.post<Student>(this.apiUrl, student);
  }

  deleteStudent(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
