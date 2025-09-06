import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Student, StudentService } from '../../services/student';

@Component({
  selector: 'app-student-list',
  imports: [CommonModule, RouterModule],
  templateUrl: './student-list.html',
  styleUrl: './student-list.css'
})
export class StudentList {
  students = signal<Student[]>([]);

  constructor(private studentService: StudentService) { }


  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getStudents().subscribe({
      next: (data) => this.students.set(data),
      error: (err) => console.error("Error Fetching students", err)
    });
  }

  deleteStudent(id: number) {
    if (confirm('Are you sure you want to delete this student?')) {

      this.studentService.deleteStudent(id).subscribe({
        next: () => {
          alert('Student deleted successfully!');
          this.loadStudents();
        },
        error: (err) => console.error('error deleting students', err)
      })
    }
  }

}
